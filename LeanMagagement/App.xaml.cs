using DevExpress.Xpf.Core;
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
        public static CultureInfo culture = new CultureInfo("vn-VI");
        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationThemeHelper.ApplicationThemeName = Theme.Win11LightName;
            base.OnStartup(e);
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}
