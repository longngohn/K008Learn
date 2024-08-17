using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorlds
{
    [TestFixture] 
    public class Lesson1
    {
        [Test]
        public void Test()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            //Code bắt đầu chạy

            int soCanBo = 3;
            double baocaoTaiChinhHopNhat = 3000.8305973845;
            string hovaTen = "Nguyen Van A";
            char kyTu = 'h';
            bool coAtCoKhong = false;

            //Cách ép kiểu thứ 1
            soCanBo = (int)baocaoTaiChinhHopNhat;
            
            //Cách ép kiểu thứ 2
            soCanBo = Convert.ToInt32(baocaoTaiChinhHopNhat);

            Console.WriteLine("Kiểu của số Cán Bộ là " + soCanBo.GetType());
            Console.WriteLine(soCanBo);

            //Kết thúc code
            watch.Stop();
            Console.WriteLine("Thời gian chạy code: " + watch.Elapsed);

            
        }

    }
}
