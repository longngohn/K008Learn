using DevExpress.Data.Entity;
using DevExpress.Xpf.Core;
using LeanMagagement.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LeanMagagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CultureInfo cul = new CultureInfo(LeanMagagement.Properties.Settings.Default.LangName);

        public static string UserId = "CB097C69-980B-4F0D-9A2A-4770D4BB51BC";

        public static string connectString { get; set; } = "Server=localhost;Database=iTask;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public static DbContextOptionsBuilder<iTaskDbContext> op = new DbContextOptionsBuilder<iTaskDbContext>();
        public static iTaskDbContext dbContext;
        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationThemeHelper.ApplicationThemeName = Theme.Win11LightName;
            base.OnStartup(e);
            Thread.CurrentThread.CurrentCulture = cul;
            Thread.CurrentThread.CurrentUICulture = cul;

            CultureInfo.DefaultThreadCurrentCulture = cul;
            CultureInfo.DefaultThreadCurrentUICulture = cul;

            op.UseSqlServer(App.connectString);
            dbContext = new iTaskDbContext(op.Options);

        }
    }
}
