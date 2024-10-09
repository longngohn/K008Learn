using LeanMagagement.CLasses;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace LeanMagagement.Models
{
    [TestFixture]
    public class mSQLServer
    {
        [Test]
        public static async Task Test()
        {
            var kq = await GetAllUsers();
            Console.WriteLine(kq.Count);
        }
        public static string connectionString = "Server=LAPTOP-B6PRDD12\\FERP;Database=iTask;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public static async Task<List<clUser>> GetAllUsers()
        {
            var uList = new List<clUser>();

            try
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        
                        cmd.CommandText = "SELECT * FROM [Users]";
                        var reader = await cmd.ExecuteReaderAsync();
                        var dt = new DataTable();
                        dt.Load(reader);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            uList = JToken.FromObject(dt).ToObject<List<clUser>>();
                        }

                    }
                }
               

            }
            catch (global::System.Exception)
            {

                throw;
            }
            return uList;
        }

        public static async Task<bool> AddUser(clUser user)
        {

            var res = false;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using(var trans = conn.BeginTransaction())
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            try
                            {
                                cmd.Parameters.AddWithValue("Id", user.Id);
                                cmd.Parameters.AddWithValue("UserName", user.UserName);
                                cmd.Parameters.AddWithValue("Email", user.Email);
                                cmd.Parameters.AddWithValue("DateOfBirth", user.DateOfBirth);
                                cmd.Parameters.AddWithValue("Address", user.Address);
                                cmd.Parameters.AddWithValue("Photo", user.Photo);

                                cmd.CommandText = "INSERT INTO ([Users] ([Id],[UserName],[Email],[DateOfBirth], [Address], [Photo]) VALUE (@Id, @UserName, @Email, @DateOfBirth, @Address, @Photo)";
                                var kq = await cmd.ExecuteNonQueryAsync();
                                if (kq > 0)
                                {
                                    res = true;
                                }

                                trans.Commit();

                            }
                            catch (Exception)
                            {

                                trans.Rollback();
                            }
                            
                        }   
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            } 
           

            return res;
        }

    }
}
