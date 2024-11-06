using DevExpress.Xpf.Controls.ThemeKeys;
using DevExpress.XtraSpreadsheet.Import.OpenXml;
using LeanMagagement.Libs;
using LeanMagagement.View.Pages;
using LeanMagagement.View.Pages.PopUp;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LeanMagagement.ViewModel
{
    public class vmMain : PropertyChangedBase
    {
        private Page _MainFrameContent;
        public Page MainFrameContent
        {
            get { return _MainFrameContent; }

            set
            {
                _MainFrameContent = value;
                OnPropertyChanged();
            }
        }

        private Page _PopUpFrameContent;
        public Page PopUpFrameContent
        {
            get { return _PopUpFrameContent; }

            set
            {
                _PopUpFrameContent = value;
                OnPropertyChanged();
            }
        }

        private bool _IsPopUp;
        public bool IsPopUp
        {
            get { return _IsPopUp; }

            set
            {
                _IsPopUp = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand cmd_OpenMainPage;

        public ICommand Cmd_OpenMainPage
        {
            get
            {
                if (cmd_OpenMainPage == null)
                {
                    cmd_OpenMainPage = new ActionCommand(PerformCmd_OpenMainPage);
                }

                return cmd_OpenMainPage;
            }
        }

        private void PerformCmd_OpenMainPage(object parameter)
        {
            string ActionName = parameter as String;
            try
            {
                switch (ActionName)
                {
                    case "pGiaoViec":
                        MainFrameContent = new pGiaoViec();
                        break;
                    case "pNguoiDung":
                        MainFrameContent = new pNguoiDung();
                        break;
                    case "pThongTinTaiKhoan":
                        PopUpFrameContent = new pThongTinTaiKhoan();
                        IsPopUp = true;
                        break;

                    default:
                        break;
                }
            }
            catch
            {

            }
        }

        private ActionCommand cmd_ClosePopUp;

        public ICommand Cmd_ClosePopUp
        {
            get
            {
                if (cmd_ClosePopUp == null)
                {
                    cmd_ClosePopUp = new ActionCommand(PerformCmd_ClosePopUp);
                }

                return cmd_ClosePopUp;
            }
        }

        private void PerformCmd_ClosePopUp()
        {
            PopUpFrameContent = null;
            IsPopUp = false;
        }

        private ActionCommand cmd_SetLanguage;

        public ICommand Cmd_SetLanguage
        {
            get
            {
                if (cmd_SetLanguage == null)
                {
                    cmd_SetLanguage = new ActionCommand(PerformCmd_SetLanguage);
                }

                return cmd_SetLanguage;
            }
        }

        private void PerformCmd_SetLanguage(object parameter)
        {
            Properties.Settings.Default.LangName = (parameter as string);
            Properties.Settings.Default.Save();

            Process.Start(Assembly.GetExecutingAssembly().Location);
            Environment.Exit(0);

        }
    }
}
