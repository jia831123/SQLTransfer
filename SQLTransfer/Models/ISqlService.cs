﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTransfer.Models
{
    interface ISqlService
    {

        string GetSQLDeleteStrig();
        string GetSQLConnectedString();
        string GetSQLSelectAllString();
        string GetSQLTableInfoString();

    }
    class SqlService : ISqlService
    {
        private string _serverName;
        private string _userName;
        private string _password;
        private string _dataBase = "master";
        private string _tableName;
        public string ServerName { get { return _serverName; } set { _serverName = value.Trim(); } }
        public string UserName { get { return _userName; } set { _userName = value.Trim(); } }
        public string Password { get { return _password; } set { _password = value.Trim(); } }
        public string DataBase { get { return _dataBase; } set { _dataBase = value.Trim(); } }
        public string TableName { get { return _tableName; } set { _tableName = value.Trim(); } }
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
                else
                {
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

        public string GetSQLConnectedString()
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
        public string GetSQLSelectAllString()
        {
            string r = $"SELECT * FROM {TableName}";
            return r;


        }
        public string GetSQLTableInfoString()
        {

            return "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";


        }
        public virtual string GetSQLDeleteStrig()
        {
            throw new NotImplementedException();
        }

    }
    class SourceSqlService : SqlService
    {
        public override string GetSQLDeleteStrig()
        {
            throw new Exception("錯誤!來源資料庫不可執行刪除動作!");
        }

    }

    class TargetSqlService : SqlService
    {
        public override string GetSQLDeleteStrig()
        {
            return $"TRUNCATE TABLE  {TableName}";
        }

    }

    abstract class Creator
    {
        public abstract ISqlService CreateSqlService();
    }
    class SourceCreator : Creator
    {
        public override ISqlService CreateSqlService()
        {
            return new SourceSqlService();
        }
    }
    class TargetCreator : Creator
    {
        public override ISqlService CreateSqlService()
        {
            return new TargetSqlService();
        }
    }
}
