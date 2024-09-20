using LeanMagagement.CLasses;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LeanMagagement.Libs;
using System.Data.SQLite;

namespace LeanMagagement.ViewModel
{
    public class vmGiaoViec
    {

		private ObservableRangeCollection<clTask> _taskList = new ObservableRangeCollection<clTask>();

		public ObservableRangeCollection<clTask> TaskList
		{
			get { return _taskList; }
			set { _taskList = value; }
		}

		public vmGiaoViec()
		{
			TaskList.Add(new clTask { ID = 1, TenCongViec = "Rà soát Hợp đồng pháp lý GIP", MoTa = "Hợp đồng ngày 11.09.2024 Malaysia", NgayTao = DateTime.Now, NguoiGiao = "Ms Thơm", NguoiNhan = "Mr Long" });
			TaskList.Add(new clTask { ID = 2, TenCongViec = "Tạo Logo công ty ReskiLaw", MoTa = "Logo mang đậm nét Thị trấn Đu", NgayTao = DateTime.Now, NguoiGiao = "Ms Thơm", NguoiNhan = "Mr Long" });
            TaskList.Add(new clTask { ID = 3, TenCongViec = "Tạo trang web Reskilaw", MoTa = "Đầy đủ thông tin về Reskilaw", NgayTao = DateTime.Now, NguoiGiao = "Ms Thơm", NguoiNhan = "Mr Long" });

        }

        private ActionCommand cmd_ThemCongViec;

        public ICommand Cmd_ThemCongViec
        {
            get
            {
                if (cmd_ThemCongViec == null)
                {
                    cmd_ThemCongViec = new ActionCommand(PerformCmd_ThemCongViec);
                }

                return cmd_ThemCongViec;
            }
        }

        private void PerformCmd_ThemCongViec()
        {
            var win = new vTaskAdd();
            win.ShowDialog();
            var task = (win.DataContext as vmTaoGiaoViec).Task;
            task.NgayTao = DateTime.Now;
            TaskList.Add(task);
        }

        private ActionCommand cmd_KichChuotPhai;

        public ICommand Cmd_KichChuotPhai
        {
            get
            {
                if (cmd_KichChuotPhai == null)
                {
                    cmd_KichChuotPhai = new ActionCommand(PerformCmd_KichChuotPhai);
                }

                return cmd_KichChuotPhai;
            }
        }

        private void PerformCmd_KichChuotPhai()
        {
            MessageBox.Show("Bạn đã click chuột phải!");
        }

        private ActionCommand cmd_TaoCSDL;

        public ICommand Cmd_TaoCSDL
        {
            get
            {
                if (cmd_TaoCSDL == null)
                {
                    cmd_TaoCSDL = new ActionCommand(PerformCmd_TaoCSDL);
                }

                return cmd_TaoCSDL;
            }
        }

        private void PerformCmd_TaoCSDL()
        {
            SQLiteConnection _con = new SQLiteConnection();
            
                string _strConnect = "Data Source=MyDatabase.sqlite;Version=3;";
                _con.ConnectionString = _strConnect;
                _con.Open();


                _con.Close();
            
        }
    }
}
