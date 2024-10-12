using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using LeanMagagement.Models;
using LeanMagagement.View.Pages.PopUp;
using LeanMagagement.View.Pages;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpUser :PropertyChangedBase
    {
        private ObservableRangeCollection<clUser> _userList = new ObservableRangeCollection<clUser>();

        public ObservableRangeCollection<clUser> UserList
        {
            get { return _userList; }
            set { _userList = value; OnPropertyChanged(); }
        }

        private ActionCommand cmd_LoadAll;

        public ICommand Cmd_LoadAll
        {
            get
            {
                if (cmd_LoadAll == null)
                {
                    cmd_LoadAll = new ActionCommand(PerformCmd_LoadAll);
                }

                return cmd_LoadAll;
            }
        }

        private async void PerformCmd_LoadAll()
        {
            try
            {
                UserList.Clear();
                var uList = await mSQLServer.GetAllUsers();
                UserList.AddRange(uList);
            }
            catch
            {

            }
        }

        private ActionCommand cmd_Popup;

        public ICommand Cmd_Popup
        {
            get
            {
                if (cmd_Popup == null)
                {
                    cmd_Popup = new ActionCommand(PerformCmd_Popup);
                }

                return cmd_Popup;
            }
        }

        private void PerformCmd_Popup(object parameter)
        {
            string ActionName = parameter as String;
            var vmMain = App.Current.MainWindow.DataContext as vmGiaoViec2;
            try
            {
                switch (ActionName)
                {
                   
                    case "pAddUser":
                        vmMain.PopUpFrameContent = new pUserInfo();

                        (vmMain.PopUpFrameContent.DataContext as vmpUserInfo).User = new clUser();

                        vmMain.IsPopUp = true;
                        break;

                    case "pEditUser":
                        vmMain.PopUpFrameContent = new pUserInfo();
                        vmMain.IsPopUp = true;
                        break;

                    default:
                        break;
                }
            }
            catch
            {

            }
        }
    }
}
