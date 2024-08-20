using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorlds
{
    
    public abstract class HinhHoc
    {
        public string Ten { get; set; } 
        public double DienTich { get; set; }

        public abstract void TinhDienTich();
    }

    public class HinhVuong : HinhHoc
    {
        public int Canh { get; set; }
        public override void TinhDienTich()
        {
            DienTich = Canh * Canh;
            Console.WriteLine("Diện tích của {0} = {1} ", Ten, DienTich);
        }
    }

    public class HinhTron : HinhHoc
    {
        public int DuongKinh { get; set; }
        public override void TinhDienTich()
        {
            DienTich = Math.PI * Math.Pow((DuongKinh / 2), 2);
            Console.WriteLine("Diện tích của {0} = {1} ", Ten, DienTich);
        }
    }

    [TestFixture]
    public class DienTichHinhHoc
    {
        [Test]
       public void TinhDienTichHinhHoc()
        {
            HinhVuong hv = new HinhVuong();
            hv.Ten = "Hình vuông";
            hv.Canh = 10;
            hv.TinhDienTich();

            HinhTron ht = new HinhTron();
            ht.Ten = "Hình tròn";
            ht.DuongKinh = 5;
            ht.TinhDienTich();
        }
    }


}
