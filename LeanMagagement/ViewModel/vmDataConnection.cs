using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.SQLite;
namespace LeanMagagement.ViewModel
{
    public class vmDataConnection
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

        private ActionCommand connectToDatabase;

        public ICommand ConnectToDatabase
        {
            get
            {
                if (connectToDatabase == null)
                {
                    connectToDatabase = new ActionCommand(PerformConnectToDatabase);
                }

                return connectToDatabase;
            }
        }

        private void PerformConnectToDatabase()
        {
          
        }
    }
}
