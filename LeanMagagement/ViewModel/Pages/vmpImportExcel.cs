
using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using LeanMagagement.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                    ReadExcelFile(FilePath);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadExcelFile(string filePath)
        {
            UserList.Clear();
            var ExcelApp = new Excel.Application();
            ExcelApp.Visible = true;

            var wb= ExcelApp.Workbooks.Open(filePath);
            Worksheet ws = wb.Sheets["Sheet1"];

            

            long lr = (ws.Cells[ws.Rows.Count, 1] as Range).End[XlDirection.xlUp].Row;

            var tlist = new List<clUser>();
            for (long i = 2; i <= lr; i++) {

                DateTime? dt = null;

                try
                {
                    dt = ws.Range["C" + i].Value;
                }
                catch (Exception)
                {

                    try
                    {
                        dt = DateTime.ParseExact(ws.Range["C" + i].Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch
                    {

                    }
                }
                var user = new clUser
                {
                    UserName = ws.Range["A" + i].Value,
                    Email = ws.Range["B" + i].Value,
                    Address = ws.Range["D" + i].Value,
                    DateOfBirth = dt ,
                };
                tlist.Add(user);
            }

            wb.Close();
            wb = null;
            UserList.AddRange(tlist);
        }

        private ActionCommand cmd_Import;

        public ICommand Cmd_Import
        {
            get
            {
                if (cmd_Import == null)
                {
                    cmd_Import = new ActionCommand(PerformCmd_ImportAsync);
                }

                return cmd_Import;
            }
        }

        private async void PerformCmd_ImportAsync()
        {
            try
            {

                bool IsSuccess = false;

                IsSuccess = await mEF.ImportUsers(UserList.ToList(), App.dbContext);

                if (IsSuccess == true)
                {
                    var vMn = App.Current.MainWindow.DataContext as vmGiaoViec2;
                    vMn.IsPopUp = false;
                    vMn.PopUpFrameContent = null;
                    MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                    (vMn.MainFrameContent.DataContext as vmpUser).Cmd_LoadAll.Execute(null);

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
