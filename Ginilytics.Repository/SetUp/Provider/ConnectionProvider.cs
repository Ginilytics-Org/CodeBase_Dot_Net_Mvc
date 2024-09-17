using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ginilytics.Repository.SetUp.Provider
{
    public class ConnectionProvider : IDisposable
    {
        internal SqlConnection dbConn;
        private readonly string _connString;
        internal ConnectionProvider(string connString)
        {
            _connString = connString;
            OpenDBConn();
        }

        void IDisposable.Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
        }
        void OpenDBConn()
        {
            dbConn = new SqlConnection(_connString);
            dbConn.Open();
        }
    }
}
