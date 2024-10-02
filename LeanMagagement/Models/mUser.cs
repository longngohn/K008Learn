using LeanMagagement.CLasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static DevExpress.XtraEditors.Mask.MaskSettings;
namespace LeanMagagement.Models
{
    [TestFixture]
    public class mUser
    {
        [Test]
        public static void Test()
        {

        }
        public static async Task<clUser> GetUserById(string UserId)
        {
            clUser user = new clUser();

            var dbPath = @"D:\1. Long\Lap trinh\SQL\iTaskData.db";
             
            string connString = "Data Source=" + dbPath + ";Version=3";

            using(SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (var cmd=  conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("id", UserId);
                    cmd.CommandText= "SELECT * FROM UserInfo WHERE [Id]=@id" ;
                    var reader = await cmd.ExecuteReaderAsync();
                    var dt = new DataTable();
                    dt.Load(reader);

                    if(dt != null && dt.Rows.Count > 0)
                    {
                       user = JToken.FromObject(dt).ToObject<List<clUser>>().FirstOrDefault()  ;
                    }

                   
                }
            }
            
            return user;
        }


        public static async Task<bool> UpdateUser(clUser user)
        {
            var res = false;

            var dbPath = @"D:\1. Long\Lap trinh\SQL\iTaskData.db";

            string connString = "Data Source=" + dbPath + ";Version=3";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("id", user.Id);
                    cmd.Parameters.AddWithValue("UserName", user.UserName);
                    cmd.Parameters.AddWithValue("Email", user.Email);
                    cmd.Parameters.AddWithValue("DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("Address", user.Address);
                    cmd.Parameters.AddWithValue("Address", user.Photo);


                    cmd.CommandText = "UPDATE    UserInfo Set [Email]=@Email, [UserName]= @UserName, [DateOfBirth]=@DateOfBirth, [Address] =@Address, [Photo] = @Photo WHERE [Id]=@id";
                    var kq = await cmd.ExecuteNonQueryAsync();
                    if (kq > 0)
                    {
                        res = true;
                    }
                }
            }

            return res;
        }
    }
}
