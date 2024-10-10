using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using LeanMagagement.Models;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpUserInfo : PropertyChangedBase
    {
        private clUser _User = new clUser();

        public clUser User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand cmd_ChangePhoto;

        public ICommand Cmd_ChangePhoto
        {
            get
            {
                if (cmd_ChangePhoto == null)
                {
                    cmd_ChangePhoto = new ActionCommand(PerformCmd_ChangePhoto);
                }

                return cmd_ChangePhoto;
            }
        }

        private void PerformCmd_ChangePhoto()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Ảnh|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    this.User.Photo = File.ReadAllBytes(openFileDialog.FileName);
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private ActionCommand cmd_UpdateData;

        public ICommand Cmd_UpdateData
        {
            get
            {
                if (cmd_UpdateData == null)
                {
                    cmd_UpdateData = new ActionCommand(PerformCmd_UpdateData);
                }

                return cmd_UpdateData;
            }
        }

        private async void PerformCmd_UpdateData()
        {
            try
            {
                var IsSuccess = await mSQLServer.AddUser(this.User);
                if (IsSuccess == true)
                {
                    (App.Current.MainWindow.DataContext as vmGiaoViec2).IsPopUp = false;
                    (App.Current.MainWindow.DataContext as vmGiaoViec2).PopUpFrameContent = null;

                    MessageBox.Show("Thêm người dùng thành công!");
                    //try
                    //{
                    //    UserList.Clear();
                    //    var uList = await mSQLServer.GetAllUsers();
                    //    UserList.AddRange(uList);
                    //}
                    //catch
                    //{

                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có ngoại lệ xảy ra: " + ex);
            }
        }
    }
}
