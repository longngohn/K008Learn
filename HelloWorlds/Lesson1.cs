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
            double doanhThuNam2023 = 3000.8305973845;
            string hovaTen = "Nguyen Van A";
            char kyTu = 'h';
            bool coAtCoKhong = false;

            //Cách ép kiểu thứ 1
            soCanBo = (int)doanhThuNam2023;
            
            //Cách ép kiểu thứ 2
            soCanBo = Convert.ToInt32(doanhThuNam2023);

            Console.WriteLine("Kiểu của số Cán Bộ là " + soCanBo.GetType());
            Console.WriteLine(soCanBo);

            Console.WriteLine("-----------------------");

            //Array
            int[] array1D = new int[5];

            array1D[0] = 1;
            array1D[1] = 2;
            array1D[2] = 3;
            array1D[3] = 4;
            array1D[4] = 5;

            for (int i = 0; i < array1D.Length; i++)
            {
                Console.WriteLine($"Đây là phần tử thứ {array1D[i]}");
            }

            //foreach looop

            Console.WriteLine("-----------------------");
            int[] numbers = { 1, 2, 3, 4, 5 };

            foreach (var number in numbers)
            {
                Console.WriteLine("Giá trị của number là: {0}", number);
            }

            Console.WriteLine("-----------------------");
            int dayOfWeeks = 3;
            string dayName;

            switch (dayOfWeeks)
            {
                case 1: dayName = "Thứ Hai"; break;
                case 2: dayName = "Thứ Ba"; break;
                case 3: dayName = "Thứ Tư"; break;
                case 4: dayName = "Thứ Năm"; break;
                case 5: dayName = "Thứ Sáu"; break;
                case 6: dayName = "Thứ Bảy"; break;
                case 7: dayName = "Chủ Nhật"; break;
                
                default: dayName = "Không hợp lệ"; break;
            
            }
            Console.WriteLine("Ngày {0} của {1}", dayOfWeeks, dayName);


            //Điều kiện If else
            Console.WriteLine("-----------------------");
            int number = 10;

            if (number > 0)
            {
                Console.WriteLine("Số {0} là số dương", number);
            }

            else if (number < 0)
            {
                Console.WriteLine("Số {0} là số âm", number);

            }
            else
            {
                Console.WriteLine("Số {0} là số 0", number);

            }
            //Kết thúc code
            watch.Stop();
            Console.WriteLine("Thời gian chạy code: " + watch.Elapsed);
            
        }
    }
}
