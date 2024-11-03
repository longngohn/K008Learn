using DevExpress.Xpf.Controls.Primitives;
using LeanMagagement.CLasses;
using LeanMagagement.EF;
using LeanMagagement.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeanMagagement.Models
{
    public class mEF
    { 
      
        public static async Task<List<clUser>> GetAllUsers(iTaskDbContext dbContext)
        {
            List<clUser> uList = null;

            try
            {
                
                var op = new DbContextOptionsBuilder<iTaskDbContext>();
                op.UseSqlServer(App.connectString);
                dbContext = new iTaskDbContext(op.Options);
                if (dbContext.Database.CanConnect())
                {
                    uList = await dbContext.Users.AsNoTracking().ToListAsync();
                }
                else
                {

                }

            }
            catch (global::System.Exception ex)
            {

              MessageBox.Show(ex.Message);
            }
            return uList;
        }
       
        public static async Task<bool> AddUser(clUser user, iTaskDbContext dbContext)
        {

            var res = false;

            try
            {
               
                if (dbContext.Database.CanConnect())
                {
                    
                    var user_Out = user.ShallowCopy();
                    user_Out.Id = Guid.NewGuid().ToString();
                    dbContext.Users.Add(user_Out);
                    var kq = await dbContext.SaveChangesAsync();
                    if(kq > 0)
                    {
                        res = true;
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }


            return res;
        }
        
        public static async Task<bool> UpdateUser(clUser user, iTaskDbContext dbContext)
        {

            var res = false;
            clUser user_Out = null;

            try
            {
                
                if (dbContext.Database.CanConnect())
                {
                     
                    user_Out = await dbContext.Users.FindAsync(user.Id);
                    if (user_Out != null)
                    {
                        user_Out.Address = user.Address;
                        user_Out.UserName = user.UserName;
                        user_Out.Email= user.Email;
                        user_Out.DateOfBirth = user.DateOfBirth;
                        user_Out.Photo = user.Photo;
                        var kq = await dbContext.SaveChangesAsync();

                        if (kq > 0)
                        {
                            res = true;
                        }
                    }  
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }


            return res;
        }

        public static async Task<bool> DeleteUser(List<clUser> userList,  iTaskDbContext dbContext)
        {

            var res = false;

            try
            {
                
                if (dbContext.Database.CanConnect())
                {

                    dbContext.Users.RemoveRange(userList);
                    var kq = await dbContext.SaveChangesAsync();
                    if (kq > 0)
                    {
                        res = true;
                    }
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return res;
        }


        
        public static async Task<bool> ImportUsers(List<clUser> userList, iTaskDbContext dbContext)
        {

            var res = false;

            try
            {

                if (dbContext.Database.CanConnect())
                {
                    foreach (var user in userList)
                    {
                        user.Id = Guid.NewGuid().ToString();
                    }
                    
                    dbContext.Users.AddRange(userList);
                    var kq = await dbContext.SaveChangesAsync();
                    if (kq > 0)
                    {
                        res = true;
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }


            return res;
        }


        public static async Task<List<clTask>> GetAllTask(iTaskDbContext dbContext)
        {
            List<clTask> tList = null;
            try
            {
                var op = new DbContextOptionsBuilder<iTaskDbContext>();
                op.UseSqlServer(App.connectString);
                dbContext = new iTaskDbContext(op.Options);
                if (dbContext.Database.CanConnect())
                {
                    tList = await dbContext.Tasks.Include(o => o.NguoiGiao).Include(o => o.NguoiNhan).AsNoTracking().ToListAsync();
                }
                else
                {

                }
            }
            catch (global::System.Exception)
            {
                throw;
            }
            return tList;
        }
    }
}
