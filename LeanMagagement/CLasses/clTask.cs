using LeanMagagement.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.CLasses
{
    public class clTask : PropertyChangedBase
    {

		private int _id;
		public int ID
		{
			get { return _id; }
			set { _id = value; OnPropertyChanged(); }
		}

		private string _tenCongViec;
		public string TenCongViec
		{
			get { return _tenCongViec; }
			set { _tenCongViec = value; OnPropertyChanged(); }
		}

		private DateTime? _ngayTao;

		public DateTime? NgayTao
		{
			get { return _ngayTao; }
			set { _ngayTao = value; OnPropertyChanged(); }
		}

		private string _moTa;

		public string MoTa
		{
			get { return _moTa; }
			set { _moTa = value; OnPropertyChanged(); }
		}

		private string _nguoiGiao;

		public string NguoiGiao
		{
			get { return _nguoiGiao; }
			set { _nguoiGiao = value; OnPropertyChanged(); }
		}

		private string _nguoiNhan;

		public string NguoiNhan
		{
			get { return _nguoiNhan; }
			set { _nguoiNhan = value; OnPropertyChanged(); }
		}


	}
}
