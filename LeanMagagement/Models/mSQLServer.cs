using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.Models
{
    [TestFixture]
    public class mSQLServer
    {
        [Test]
        public static Task<List<clUser>> GetAllUsers()
        {
            var uList = new List<clUser>();

            try
            {

            }
            catch (global::System.Exception)
            {

                throw;
            }
            return uList;
        }
        public static async Task<clUser> GetUserById(string UserId)
        {
            clUser user = new clUser();

            var dbPath = @"D:\1. Long\Lap trinh\SQL\iTaskData.db";

            string connString = "Data Source=" + dbPath + ";Version=3";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("id", UserId);
                    cmd.CommandText = "SELECT * FROM UserInfo WHERE [Id]=@id";
                    var reader = await cmd.ExecuteReaderAsync();
                    var dt = new DataTable();
                    dt.Load(reader);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        user = JToken.FromObject(dt).ToObject<List<clUser>>().FirstOrDefault();
                    }


                }
            }

            return user;
        }
    }
}
