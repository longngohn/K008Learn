using LeanMagagement.CLasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LeanMagagement.Converter
{
    public class TrangThaiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is TrangThai TT)
                {
                    switch (TT)
                    {
                        case TrangThai.ChuaThucHien:
                            return "Chưa thực hiện";
                        case TrangThai.DangThucHien:
                            return "Đang thực hiện";
                        case TrangThai.DangKiemTra:
                            return "Đang kiểm tra";
                        case TrangThai.HoanThanh:
                            return "Hoàn thành";
                        case TrangThai.TamDung:
                            return "Tạm dừng";
                        case TrangThai.HuyBo:
                            return "Huỷ bỏ";
                    }
                }
            }
            catch
            {

            }
            return "Không có giá trị";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
