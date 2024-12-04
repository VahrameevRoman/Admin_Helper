using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Helper
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("Server=romanct3.beget.tech;Database=romanct3_adminhp;Uid=romanct3_adminhp;Pwd=Qwe123;");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection() { return connection; }
    }
}
