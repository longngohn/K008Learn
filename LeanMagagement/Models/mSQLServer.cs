﻿using LeanMagagement.CLasses;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public static async Task<List<clUser>> GetAllUsers()
        {
            var uList = new List<clUser>();

            try
            {
                var connectionString = "Server=LAPTOP-B6PRDD12\\FERP;Database=iTask;Trusted_Connection=True;MultipleActiveResultSets=true;";

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
      
    }
}
