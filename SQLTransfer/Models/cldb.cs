
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Windows.Media;

/// <summary>
/// clsDB 的摘要描述
/// </summary>
public class clsDB : IDisposable
{
    private SqlConnection objConn;
    public enum ConnStrNameEnum { DBConnection, NTPCLAND, urbanZoningConnStr, urbanPublicConnStr }


    //public clsDB()
    //{
    //    objConn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnStrNameEnum.DBConnection.ToString()].ToString());
    //}
    public clsDB(string connectString)
    {
        objConn = new SqlConnection(connectString);
    }

    //public clsDB(ConnStrNameEnum ConnStrName)
    //{
    //    objConn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnStrName.ToString()].ToString());
    //}

    /// <summary>
    /// 關閉連線
    /// </summary>
    public void Dispose()
    {
        if (objConn.State != ConnectionState.Closed)
        {
            objConn.Close();
        }
    }

    /// <summary>
    /// 執行語法
    /// </summary>
    /// <param name="sql">語法</param>
    /// <param name="sqlParams">參數</param>
    /// <param name="IsTry">是否嘗試</param>
    /// <returns>return bool</returns>
    public bool ToExecute(string sql, SqlParameter[] sqlParams = null, bool IsTry = false)
    {
        bool result = true;
        SqlCommand objCmd = new SqlCommand(sql, objConn);
        bool cmdClean = false;

        if (IsTry)
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }

                if (sqlParams != null)
                {
                    objCmd.Parameters.AddRange(sqlParams);
                    cmdClean = !cmdClean;
                }

                objCmd.ExecuteNonQuery();

                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }
            }
            catch
            {
                result = false;
            }
        }
        else
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            if (sqlParams != null)
            {
                objCmd.Parameters.AddRange(sqlParams);
                cmdClean = !cmdClean;
            }

            objCmd.ExecuteNonQuery();

            if (objConn.State != ConnectionState.Closed)
            {
                objConn.Close();
            }
        }
        if (cmdClean)
        {
            objCmd.Parameters.Clear();
        }
        return result;
    }

    /// <summary>
    /// 回傳讀取器
    /// </summary>
    /// <param name="sql">語法</param>
    /// <param name="sqlParams">參數</param>
    /// <returns>return SqlDataReader</returns>
    public SqlDataReader ToReader(string sql, SqlParameter[] sqlParams = null)
    {
        SqlCommand objCmd = new SqlCommand(sql, objConn);

        if (objConn.State != ConnectionState.Open)
        {
            objConn.Open();
        }

        if (sqlParams != null)
        {
            objCmd.Parameters.AddRange(sqlParams);
        }

        SqlDataReader objRdr = objCmd.ExecuteReader();

        return objRdr;
    }

    /// <summary>
    /// 回傳資料表
    /// </summary>
    /// <param name="sql">語法</param>
    /// <param name="sqlParams">參數</param>
    /// <returns>return DataTable</returns>
    public DataTable ToDataTable(string sql, SqlParameter[] sqlParams = null)
    {
        DataTable objTab = new DataTable();
        bool cmdClean = false;
        SqlCommand objCmd = new SqlCommand(sql, objConn);

        if (sqlParams != null)
        {
            objCmd.Parameters.AddRange(sqlParams);
            cmdClean = !cmdClean;
        }

        SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
        objDa.Fill(objTab);

        if (cmdClean)
        {
            objCmd.Parameters.Clear();
        }
        //objTab = setDataTable(objTab);
        return objTab;
    }

    /// <summary>
    /// 回傳資料表
    /// </summary>
    /// <param name="sql">語法</param>
    /// <param name="sqlParams">參數</param>
    /// <returns>return DataSet</returns>
    public DataSet ToDataSet(string sql, SqlParameter[] sqlParams = null)
    {
        DataSet objDs = new DataSet();

        SqlCommand objCmd = new SqlCommand(sql, objConn);

        if (sqlParams != null)
        {
            objCmd.Parameters.AddRange(sqlParams);
        }

        SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
        objDa.Fill(objDs);

        return objDs;
    }

    /// <summary>
    /// 回傳單筆資料
    /// </summary>
    /// <param name="sql">語法</param>
    /// <param name="sqlParams">參數</param>
    /// <returns>return string，空值回傳'Null'</returns>
    public string getResult(string sql, SqlParameter[] sqlParams = null)
    {
        SqlCommand objCmd = new SqlCommand(sql, objConn);
        bool cmdClean = false;
        string objStr = string.Empty;
        if (sqlParams != null)
        {
            objCmd.Parameters.AddRange(sqlParams);
            cmdClean = !cmdClean;
        }

        if (objConn.State != ConnectionState.Open)
        {
            objConn.Open();

        }
        var obj = objCmd.ExecuteScalar();
        if (obj == null)
        {
            objStr = "Null";
        }
        else
        {
            objStr = obj.ToString();
        }
        if (cmdClean)
        {
            objCmd.Parameters.Clear();
        }
        return objStr;
    }
    /// <summary>
    /// 將dataTable做XXS過濾
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>

}

//-----------------------------------------------------------------------------------------
public static class DataTableExtensions
{
    public static IList<T> ToList<T>(this DataTable table) where T : new()
    {
        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
        IList<T> result = new List<T>();

        //取得DataTable所有的row data
        foreach (var row in table.Rows)
        {
            var item = MappingItem<T>((DataRow)row, properties);
            result.Add(item);
        }

        return result;
    }

    private static T MappingItem<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    {
        T item = new T();
        foreach (var property in properties)
        {
            if (row.Table.Columns.Contains(property.Name))
            {
                //針對欄位的型態去轉換
                if (property.PropertyType == typeof(DateTime))
                {
                    DateTime dt = new DateTime();
                    if (DateTime.TryParse(row[property.Name].ToString(), out dt))
                    {
                        property.SetValue(item, dt, null);
                    }
                    else
                    {
                        property.SetValue(item, null, null);
                    }
                }
                else if (property.PropertyType == typeof(double))
                {
                    double val = new double();
                    if (double.TryParse(row[property.Name].ToString(), out val))
                    {
                        property.SetValue(item, val, null);
                    }
                    else
                    {
                        property.SetValue(item, null, null);
                    }
                }
                else if (property.PropertyType == typeof(int))
                {
                    int val = new int();
                    if (int.TryParse(row[property.Name].ToString(), out val))
                    {
                        property.SetValue(item, val, null);
                    }
                    else
                    {
                        property.SetValue(item, null, null);
                    }
                }
                else if (property.PropertyType == typeof(bool))
                {
                    bool val = new bool();
                    if (bool.TryParse(row[property.Name].ToString(), out val))
                    {
                        property.SetValue(item, val, null);
                    }
                    else
                    {
                        property.SetValue(item, null, null);
                    }
                }
                else if (property.PropertyType == typeof(Byte))
                {
                    Byte val = new Byte();
                    if (Byte.TryParse(row[property.Name].ToString(), out val))
                    {
                        property.SetValue(item, val, null);
                    }
                    else
                    {
                        property.SetValue(item, null, null);
                    }
                }
                else if (property.PropertyType == typeof(Geometry))
                {
                    Geometry val = Geometry.Parse(row[property.Name].ToString());
                    property.SetValue(item, val, null);
                }
                else
                {
                    if (row[property.Name] != DBNull.Value)
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                }
            }
        }
        return item;
    }
}