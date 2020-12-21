using SQLTransfer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLTransfer
{
    public partial class Form1 : Form
    {
        private SourceSqlService _sourceSqlService;
        private TragetSqlService _tragetSqlService;
        public Form1()
        {
            InitializeComponent();
            SourceSqlService SourceSqlService = new SourceSqlService();
            _sourceSqlService = SourceSqlService;
            TragetSqlService TragetSqlService = new TragetSqlService();
            _tragetSqlService = TragetSqlService;

            if (ConfigurationManager.AppSettings["serRemember"].Equals("true")) 
            {
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                //MessageBox.Show(
                ////    "Remember:" + cfa.AppSettings.Settings["serRemember"].Value.ToString() + 
                ////    ";ServerName:" + cfa.AppSettings.Settings["serName"].Value.ToString()+
                ////    ";UserName:" + cfa.AppSettings.Settings["serUName"].Value.ToString()+
                ////    ";PassWord:" + cfa.AppSettings.Settings["serPWord"].Value.ToString()
                ////    );
                ////MessageBox.Show(
                ////   "fuck"
                ////    );
                ServerName_Source.Text =_sourceSqlService.ServerName = cfa.AppSettings.Settings["serName"].Value.ToString();
                UserName_Source.Text = _sourceSqlService.UserName   = cfa.AppSettings.Settings["serUName"].Value.ToString();
                Password_Source.Text =_sourceSqlService.Password   = cfa.AppSettings.Settings["serPWord"].Value.ToString();
                SaveInputData_Source.Checked = true;
            }
            if (ConfigurationManager.AppSettings["traRemember"].Equals("true"))
            {
                
                _tragetSqlService.ServerName = ConfigurationManager.AppSettings["traName"];
                _tragetSqlService.UserName = ConfigurationManager.AppSettings["traUName"] ;
                _tragetSqlService.Password = ConfigurationManager.AppSettings["traPWord"] ;
                ServerName_Traget.Text = _tragetSqlService.ServerName;
                UserName_Traget.Text = _tragetSqlService.UserName;
                Password_Traget.Text = _tragetSqlService.Password;
                SaveInputData_Traget.Checked = true;
            }
        }

        private void DateBase_SelectedClick(object sender, EventArgs e)
        {
            SqlService _sqlService;
            ComboBox _dataBase;
            ComboBox _sender = sender as ComboBox;
            if (_sender.Name == "DataBase_Source")
            {
                _sqlService = _sourceSqlService;
                _dataBase = DataBase_Source;

            }
            else 
            {
                _sqlService = _tragetSqlService;
                _dataBase = DataBase_Traget;
            }
            DateBaseSelectClick(_sqlService, _dataBase);
        }

        private void DateBaseSelectClick(
            SqlService sqlService, 
            ComboBox dataBase) 
        {
            SqlService _sqlService = sqlService;
            ComboBox _DataBase = dataBase;
            _sqlService.ServerName = ServerName_Source.Text;
            _sqlService.UserName = UserName_Source.Text;
            _sqlService.Password = Password_Source.Text;


            if (!_sqlService.IsSqlConnectinfoComplete)
            {
                return;
            }
            Ping pingSender = new Ping();
            if (_sqlService.ServerName != ".")
            {
                PingReply reply = null;
                try
                {
                    reply = pingSender.Send(_sqlService.ServerName, 120);
                }
                catch
                {
                    DialogResult dr = MessageBox.Show("IP位置無效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (reply.Status != IPStatus.Success)
                {
                    DialogResult dr = MessageBox.Show("IP位置錯誤", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try 
            {
                using (clsDB db = new clsDB(_sqlService.SQLConnectingString))
                {
                    try
                    {
                        string sql = "SELECT name FROM master.dbo.sysdatabases";
                        var dt = db.ToDataTable(sql);
                        _DataBase.Items.Clear();
                        foreach (DataRow Items in dt.Rows)
                        {

                            _DataBase.Items.Add(Items["name"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataBase_SourceChangeValue(object sender, EventArgs e) 
        {
            SqlService _sqlService;
            ComboBox _tabelName;
            ComboBox _sender = sender as ComboBox;
            if (_sender.Name == "DataBase_Source")
            {
                _sourceSqlService.DataBase = DataBase_Source.Text;
                _sqlService = _sourceSqlService;
                _tabelName = TableName_Source;
                
            }
            else
            {
                _tragetSqlService.DataBase = DataBase_Traget.Text;
                _sqlService = _tragetSqlService;
                _tabelName = TableName_Traget;
            }
            DateBaseSelectChange(_sqlService, _tabelName);

        }
        private void DateBaseSelectChange(
            SqlService sqlService,
            ComboBox tabelName
            ) 
        {
            SqlService _sqlService= sqlService;
            ComboBox _tabelName = tabelName;
            _tabelName.Enabled = true;
            _sqlService.TableName = _tabelName.Text;
            using (clsDB db = new clsDB(_sqlService.SQLConnectingString))
            {
                try
                {
                    _tabelName.Items.Clear();
                    _sqlService.TableInfo = db.ToDataTable(_sqlService.SQLTableInfoString);
                    foreach (DataRow Items in _sqlService.TableInfo.Rows)
                    {

                        _tabelName.Items.Add(Items["TABLE_NAME"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState != CheckState.Checked)
            {
                UserName_Source.Enabled = true;
                Password_Source.Enabled = true;
                _sourceSqlService.IsAuthentica = true;
            }
            else {
                UserName_Source.Enabled = !true;
                Password_Source.Enabled = !true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime stratTime = DateTime.Now;
            int dataCounts;
            try
            {
                //Step1.從SQL_Source將資料全部取下來
                using (clsDB db = new clsDB(_sourceSqlService.SQLConnectingString))
                {
                    _sourceSqlService.Data = db.ToDataTable(_sourceSqlService.SQLSelectAllString);
                    dataCounts = _sourceSqlService.Data.Rows.Count;
                }
                //Step2.將SQL_Traget表資料刪除
                using (clsDB db = new clsDB(_tragetSqlService.SQLConnectingString))
                {
                    db.ToExecute(_tragetSqlService.DeleteSQLString);
                }
                //Step3.將資料Inser進SQL_Traget
                using (var sql = new SqlConnection(_tragetSqlService.SQLConnectingString))
                {
                    sql.Open();
           
                    using (var sqlBulkCopy = new SqlBulkCopy(sql))
                    {
                        if (dataCounts > 10000) 
                        {
                            sqlBulkCopy.BatchSize = 10000;
                            sqlBulkCopy.BulkCopyTimeout = 300;
                        }
                        sqlBulkCopy.DestinationTableName = _tragetSqlService.TableName;
                        sqlBulkCopy.WriteToServer(_sourceSqlService.Data);
                    }
                    sql.Close();
                }
                DateTime stopTime = DateTime.Now;
                TimeSpan span = stopTime.Subtract(stratTime);
                var minScond = span.TotalSeconds.ToString();
                MessageBox.Show($"Success! {dataCounts} rows of data were transfered AND Takes {minScond} seconds", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
  
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
            InitializeComponent();
        }

        private void UpdateTransferState(object sender, EventArgs e)
        {
            _sourceSqlService.TableName = TableName_Source.Text;
            _tragetSqlService.TableName = TableName_Traget.Text;
            if (_sourceSqlService.IsSqlTransferComplete && _tragetSqlService.IsSqlTransferComplete)
            {
                Transfer.Enabled = true;
            }
            else 
            {
                Transfer.Enabled = false;
            }
        }

        private void SaveInputData(object sender, EventArgs e) 
        {
            CheckBox _sender = sender as CheckBox;
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (_sender.Checked)
            {
                if (_sender.Name == "SaveInputData_Source")
                {
                    config.AppSettings.Settings["serName"].Value = ServerName_Source.Text;
                    config.AppSettings.Settings["serUName"].Value = UserName_Source.Text.ToString();
                    config.AppSettings.Settings["serPWord"].Value = Password_Source.Text.ToString();


                    config.AppSettings.Settings["serRemember"].Value= "true";
                }
                else
                {
                    config.AppSettings.Settings["traName"].Value = ServerName_Traget.Text;
                    config.AppSettings.Settings["traUName"].Value = UserName_Traget.Text;
                    config.AppSettings.Settings["traPWord"].Value = Password_Traget.Text;
                    config.AppSettings.Settings["traRemember"].Value = "true";


                }
            }
            else 
            {
                if (_sender.Name == "SaveInputData_Source")
                {
                    config.AppSettings.Settings["serName"].Value = "";
                    config.AppSettings.Settings["serUName"].Value = "";
                    config.AppSettings.Settings["serPWord"].Value = "";
                    config.AppSettings.Settings["serRemember"].Value = "false";
                }
                else
                {
                    config.AppSettings.Settings["traName"].Value = "";
                    config.AppSettings.Settings["traUName"].Value = "";
                    config.AppSettings.Settings["traPWord"].Value = "";
                    config.AppSettings.Settings["traRemember"].Value = "false";
                }
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            //MessageBox.Show(
            //          "Remember:" + ConfigurationManager.AppSettings["serRemember"].ToString() +
            //          ";ServerName:" + ConfigurationManager.AppSettings["serName"].ToString() +
            //          ";UserName:" + ConfigurationManager.AppSettings["serUName"].ToString() +
            //          ";PassWord:" + ConfigurationManager.AppSettings["serPWord"].ToString()
            //          );
        }



        private void Info_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("By Peter 2020", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
