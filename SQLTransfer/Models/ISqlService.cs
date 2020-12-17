using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTransfer.Models
{
     interface ISqlService
    {

    }
      class SqlService
    {
        private string _serverName; 
        private string _userName;
        private string _password;
        private string _dataBase;
        private string _tableName="master";
        public string ServerName { get { return _serverName; } set { _serverName = value.Trim(); } }
        public string UserName { get { return _userName; } set { _userName = value.Trim(); } }
        public string Password { get { return _password; } set { _password = value.Trim(); } }
        public string DataBase { get { return _dataBase; } set { _dataBase = value.Trim(); } }
        public string TableName { get { return _tableName; } set { _tableName = value.Trim(); } }
        public string SQLConnectingString 
        {
            get 
            {
                string r;
                if (IsAuthentica)
                {
                    r = $"" +
                    $"Data Source={ServerName};" +
                    $"DataBase={_dataBase};" +
                    $"integrated security=true; ";
                   
                }
                else 
                {
                    r = $"" +
                    $"Data Source={ServerName};" +
                    $"DataBase={_dataBase};" +
                    $"User Id={UserName};" +
                    $"Password={Password};";
                }
                return r;
            }
        }
        public string SQLSelectAllString 
        { get 
            {
                string r = $"SELECT * FROM {TableName}";
                return r;
            } 
        
        }
        public string SQLTableInfoString
        {
            get
            {
                return "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
            }

        }
        public bool IsAuthentica { get; set; } = false;
        public bool IsSqlConnectinfoComplete 
        {
            get 
            {
                if (IsAuthentica)
                {
                    if (
                        string.IsNullOrWhiteSpace(ServerName) ||
                        string.IsNullOrWhiteSpace(DataBase) 
                        ) { return false; }
                }
                else {
                    if (
                        string.IsNullOrWhiteSpace(ServerName) ||
                        string.IsNullOrWhiteSpace(UserName) ||
                        string.IsNullOrWhiteSpace(Password)
                        ) { return false; }
                }
                return true;
            }
        }
        public bool IsSqlTransferComplete 
        {
            get
            {
                if (IsSqlConnectinfoComplete)
                {
                    if (
                        !string.IsNullOrWhiteSpace(_dataBase) &&
                        !string.IsNullOrWhiteSpace(_tableName)
                        ) { return true; }
                }
                return false;
            }

        }
        public List<string> DataBaseList { get; set; }
        public DataTable TableInfo { get; set; }
        public DataTable Data { get; set; }
    }
    class SourceSqlService : SqlService
    {
    
    }

    class TragetSqlService : SqlService
    {
        public string DeleteSQLString
        {
            get
            {
                string r = $"DELETE FROM  {TableName}";
                return r;
            }
        }

    }
}
