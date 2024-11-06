using DevExpress.Data.Browsing;
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
    public class vmpAccInfo :PropertyChangedBase
    {
		private clUser _User;

		public clUser User
		{
			get { return _User; }
			set { _User = value;
				OnPropertyChanged();
			}
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
                this.User = await mUser.GetUserById(App.UserId);
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

        private async void PerformCmd_UpdateData(object parameter)
        {
            try
            {
                var kq = await mUser.UpdateUser(this.User);
                if (kq == true)
                    {
                    (App.Current.MainWindow.DataContext as vmMain).IsPopUp = false;
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    }                    
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có ngoại lệ xảy ra: " + ex);
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
    }
}
