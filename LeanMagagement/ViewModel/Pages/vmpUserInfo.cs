using DevExpress.Data.Browsing;
using DevExpress.Office.Import.OpenXml;
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
        private clUser _User;

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
                bool IsSuccess = false;
                if (this.User.Id != null)
                {
                   
                    IsSuccess = await mEF.UpdateUser(this.User);

                    if (IsSuccess == true)
                    {
                        var vMn = App.Current.MainWindow.DataContext as vmGiaoViec2;
                        vMn.IsPopUp = false;
                        vMn.PopUpFrameContent = null;
                        MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                        (vMn.MainFrameContent.DataContext as vmpUser).Cmd_LoadAll.Execute(null);

                    }
                }
                else
                {
                    IsSuccess = await mEF.AddUser(this.User);
                    if (IsSuccess == true)
                    {
                        var vMn = App.Current.MainWindow.DataContext as vmGiaoViec2;
                        vMn.IsPopUp = false;
                        vMn.PopUpFrameContent = null;
                        MessageBox.Show("Thêm người dùng thành công!");
                        (vMn.MainFrameContent.DataContext as vmpUser).Cmd_LoadAll.Execute(null);

                    }
                }

                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Có ngoại lệ xảy ra: " + ex);
            }
        }
    }
}
