﻿using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LeanMagagement.ViewModel
{
    public class vmTaoGiaoViec : PropertyChangedBase
    {
		private clTask _task = new clTask();

		public clTask Task				
		{
			get { return _task; }
			set { _task = value; 
                 OnPropertyChanged(); }
		}

        private ActionCommand cmd_ThemCV;

        public ICommand Cmd_ThemCV
        {
            get
            {
                if (cmd_ThemCV == null)
                {
                    cmd_ThemCV = new ActionCommand(PerformCmd_ThemCV);
                }

                return cmd_ThemCV;
            }
        }

        private void PerformCmd_ThemCV(object par)
        {
            (par as Window).Close();
        }
    }
}
