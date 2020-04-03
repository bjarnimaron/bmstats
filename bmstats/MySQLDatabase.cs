using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebApplication2
{
    public class MySqlDatabase : IDisposable
    {
        public MySqlConnection Connection;

        public MySqlDatabase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}