using LeanMagagement.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeanMagagement.CLasses
{

    public enum TrangThai
    {
        ChuaThucHien,
		DangThucHien,
		DangKiemTra,
        HoanThanh,
		TamDung,
		HuyBo
    }

    [Table("Tasks")]
    public class clTask : PropertyChangedBase
    {

		private long _id =0;
		public long ID
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

        private string _moTa;

        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; OnPropertyChanged(); }
        }

		private DateTime? _ngayTao;

		public DateTime? NgayTao
		{
			get { return _ngayTao; }
			set { _ngayTao = value; }
		}

		private DateTime? _deadLine;

		public DateTime? DeadLine
        {
			get { return _deadLine; }
			set { _deadLine = value; OnPropertyChanged(); }
		}

		
		private TrangThai _trangThai = TrangThai.ChuaThucHien;
		public TrangThai TrangThai
		{
			get { return _trangThai; }
			set { _trangThai = value; OnPropertyChanged(); }
		}

        private string _nguoiGiaoId;

        public string NguoiGiaoId
        {
            get { return _nguoiGiaoId; }
            set { _nguoiGiaoId = value; OnPropertyChanged(); }
        }


        private clUser _nguoiGiao;

		public virtual clUser NguoiGiao
		{
			get { return _nguoiGiao; }
			set { _nguoiGiao = value; OnPropertyChanged(); }
		}

        private string _nguoiNhanId;

        public string NguoiNhanId
        {
            get { return _nguoiNhanId; }
            set { _nguoiNhanId = value; OnPropertyChanged(); }
        }

        private clUser _nguoiNhan;

		public virtual clUser NguoiNhan
		{
			get { return _nguoiNhan; }
			set { _nguoiNhan = value; OnPropertyChanged(); }
		}


	}
}
