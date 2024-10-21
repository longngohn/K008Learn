
using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

using Excel = Microsoft.Office.Interop.Excel;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpImportExcel : PropertyChangedBase
    {

        private string _filePath=null;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value;  OnPropertyChanged(); }
        }

        private ObservableRangeCollection<clUser> _userList = new ObservableRangeCollection<clUser>();

        public ObservableRangeCollection<clUser> UserList
        {
            get { return _userList; }
            set { _userList = value; OnPropertyChanged(); }
        }

        private ObservableRangeCollection<clUser> _userSelect = new ObservableRangeCollection<clUser>();

        public ObservableRangeCollection<clUser> UserSelect
        {
            get { return _userSelect; }
            set { _userSelect = value; OnPropertyChanged(); }
        }

        private ActionCommand cmd_SelectExcel;

        public ICommand Cmd_SelectExcel
        {
            get
            {
                if (cmd_SelectExcel == null)
                {
                    cmd_SelectExcel = new ActionCommand(PerformCmd_SelectExcel);
                }

                return cmd_SelectExcel;
            }
        }

        private void PerformCmd_SelectExcel()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false;
                dlg.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (dlg.ShowDialog() == true && File.Exists(dlg.FileName))
                {
                    FilePath= dlg.FileName;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadExcelFile(string filePath)
        {
            UserList.Clear();
            var ExcelApp = new Excel.Application();
            ExcelApp.Visible = true;

            var wb= ExcelApp.Workbooks.Open(filePath);
            Excel.Worksheet ws = wb.Sheets[0];

            MessageBox.Show(ws.Range["A2"].Value);

            long lr = (ws.Cells[ws.Rows.Count, 1] as Range).End[XlDirection.xlUp].Row;

            var tlist = new List<clUser>();
            for (long i = 1; i <= lr; i++) {
                var user = new clUser
                {
                    UserName = ws.Range["A" + i].Value,
                    Email = ws.Range["B" + i].Value,
                    Address = ws.Range["C" + i].Value,
                    DateOfBirth = ws.Range["D" + i].Value, 
                };
                tlist.Add(user);
            }
            UserList.AddRange(tlist);
        }
    }
}
