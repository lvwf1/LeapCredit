using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace SlarkInc.DBHelpers
{
    public class SQLDatabaseHelper
    {
        /// <summary>
        /// Returns an opened OleDbConnection.
        /// NOTE: Caller MUST handle closing of the connection (in "using" statement or Dispose).
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection GetConnection()
        {
            // string strconfig = ConfigurationManager.AppSettings["FakeCloudData"];
            string strconfig = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string strConnection = strconfig;
            strConnection = string.Format(strconfig, HttpContext.Current.Server.MapPath("~"));

            OleDbConnection conn = new OleDbConnection(strConnection);
            conn.Open();

            return conn;
        }

        public static System.Data.SqlClient.SqlConnection GetSqlConnection(string connName)
        {
            // string strconfig = ConfigurationManager.AppSettings["FakeCloudData"];
            string strconfig = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            string strConnection = strconfig;
            strConnection = string.Format(strconfig, HttpContext.Current.Server.MapPath("~"));

            SqlConnection conn = new SqlConnection(strConnection);
            conn.Open();

            return conn;
        }
    }
}