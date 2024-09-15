using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.Libs
{
    class DataBaseConnection
    {

        SQLiteConnection _con = new SQLiteConnection();
        public void createConection()
        {
            string _strConnect = "Data Source=MyDatabase.sqlite;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open();
        }
        public void closeConnection()
        {
            _con.Close();
        }
    }
}
