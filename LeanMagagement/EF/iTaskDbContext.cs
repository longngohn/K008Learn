using DevExpress.XtraBars.Docking2010.Dragging;
using LeanMagagement.CLasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.EF
{
    public class iTaskDbContext : DbContext
    {
        public DbSet<clUser> Users { get; set; }
        public iTaskDbContext(DbContextOptions<iTaskDbContext> options) : base(options) 
        { 
       

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
