using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using LeanMagagement.Models;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpTaskInfo : PropertyChangedBase
    {
        private clTask _task = new clTask();

        public clTask Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        private ObservableRangeCollection<clUser> _userList = new ObservableRangeCollection<clUser>();

        public ObservableRangeCollection<clUser> UserList
        {
            get { return _userList; }
            set { _userList = value; OnPropertyChanged(); }
        }

        private ActionCommand cmd_AddTask;

        public ICommand Cmd_AddTask
        {
            get
            {
                if (cmd_AddTask == null)
                {
                    cmd_AddTask = new ActionCommand(PerformCmd_AddTask);
                }

                return cmd_AddTask;
            }
        }

        private void PerformCmd_AddTask()
        {
            var vmMain = App.Current.MainWindow.DataContext as vmMain;
            var vmpGiaoViec = vmMain.MainFrameContent.DataContext as Pages.vmpGiaoViec;
            vmpGiaoViec.TaskList.Add(Task);
            vmMain.IsPopUp = false;
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

                var uList = await mEF.GetAllUsers(App.dbContext);

                if (Task.NguoiGiaoId != null)
                {
                    Task.NguoiGiao = uList.Where(o => o.Id == Task.NguoiGiaoId).FirstOrDefault();
                    
                }

                if (Task.NguoiNhanId != null)
                {
                    Task.NguoiNhan = uList.Where(o => o.Id == Task.NguoiNhanId).FirstOrDefault();
                }

                UserList.AddRange(uList);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        
    }
}
