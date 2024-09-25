using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpAddTask : PropertyChangedBase
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
            var vmMain = App.Current.MainWindow.DataContext as vmGiaoViec2;
            var vmpGiaoViec = vmMain.MainFrameContent.DataContext as Pages.vmpGiaoViec;
            vmpGiaoViec.TaskList.Add(Task);
            vmMain.IsPopUp = false;
        }
    }
}
