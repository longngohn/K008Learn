﻿using LeanMagagement.CLasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeanMagagement.View.Pages.PopUp
{
    /// <summary>
    /// Interaction logic for pTaskInfo.xaml
    /// </summary>
    public partial class pTaskInfo : Page
    {
        public pTaskInfo()
        {
            InitializeComponent();
            this.SttCb.ItemsSource = Enum.GetValues(typeof(TrangThai));
        }
    }
}
