﻿using DevExpress.Xpf.WindowsUI;
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
using System.Windows.Shapes;

namespace LeanMagagement.View
{
    /// <summary>
    /// Interaction logic for vTask2.xaml
    /// </summary>
    public partial class vTask2 : Window
    {
        public vTask2()
        {
            InitializeComponent();
        }

        private void HamburgerMenuBottomBarNavigationButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as HamburgerMenuBottomBarNavigationButton;
            if (button != null && button.ContextMenu != null) {
                button.ContextMenu.PlacementTarget = button;
                button.ContextMenu.IsOpen = true;

            }
        }
    }
}
