﻿using DevExpress.Pdf.Native;
using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using LeanMagagement.View.Pages.PopUp;
using Microsoft.Xaml.Behaviors.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpGiaoViec : PropertyChangedBase
    {


        private ObservableRangeCollection<clTask> _taskList = new ObservableRangeCollection<clTask>();

        public ObservableRangeCollection<clTask> TaskList
        {
            get { return _taskList; }
            set { _taskList = value; }
        }

        private ActionCommand cmd_OpenPage;

        public ICommand Cmd_OpenPage
        {
            get
            {
                if (cmd_OpenPage == null)
                {
                    cmd_OpenPage = new ActionCommand(PerformCmd_OpenPage);
                }

                return cmd_OpenPage;
            }
        }

        private void PerformCmd_OpenPage(object parameter)
        {
            string ActionName = parameter as String;
           

            try
            {
                var vmMain = App.Current.MainWindow.DataContext as vmGiaoViec2;
                switch (ActionName)
                {
                    case "pAddTask":

                        vmMain.PopUpFrameContent = new pAddTask();
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

        private ActionCommand cmd_SaveData;

        public ICommand Cmd_SaveData
        {
            get
            {
                if (cmd_SaveData == null)
                {
                    cmd_SaveData = new ActionCommand(PerformCmd_SaveData);
                }

                return cmd_SaveData;
            }
        }

        private void PerformCmd_SaveData()
        {
            Properties.Settings.Default.SaveData = JsonConvert.SerializeObject(TaskList);
            Properties.Settings.Default.Save();
            MessageBox.Show("Đã lưu dữ liệu");
        }

        private ActionCommand cmd_ReloadData;

        public ICommand Cmd_ReloadData
        {
            get
            {
                if (cmd_ReloadData == null)
                {
                    cmd_ReloadData = new ActionCommand(PerformCmd_ReloadData);
                }

                return cmd_ReloadData;
            }
        }

        private void PerformCmd_ReloadData()
        {
            try
            {
                TaskList.Clear();

                //TaskList = JToken.Parse(Properties.Settings.Default.SaveData).ToObject<ObservableRangeCollection<clTask>>();
                List<clTask> tList = JToken.Parse(Properties.Settings.Default.SaveData).ToObject<List<clTask>>();
                TaskList.AddRange(tList);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}