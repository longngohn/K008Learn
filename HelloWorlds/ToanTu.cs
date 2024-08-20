using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorlds
{
    [TestFixture]
    public class ToanTu
    {
        [Test]
        public void CongTruNhanChia()
        {
            int x = 3;
            int y = 1;

            //Cộng hai giá trị
            x = y + 1;
            x = y - 1;
            x = y * 1;
            x = y / 1;
            x = y % 1;
            x++;
            x--;
            x = 5;
            x += y;
            x -= y;
            x *= y;
            x /= y; //Nếu là 2 int thì sẽ giá trị là int, cần ép thành kiểu double nếu muốn chuyển
            x %= y;

            x = 34;

            y = 81;

            Console.WriteLine("{0}",(double)x/(double)y);

        }

        [Test]
        public void soSanh()
        {
            int age = 13;

            if (age == 13)
            {
                Console.WriteLine("Bạn không phải độ tuổi đẹp nhất");
            }
            else if(age >13 && age <= 18)
            {
                Console.WriteLine("Bạn đang ở độ tuổi đẹp nhất");
            }
            else
            {
                Console.WriteLine("Xuân còn non nghĩa là xuân đã già");
            }

            for (int a=1; a <10; a++)
            {
                Console.WriteLine("a hiện tại là số {0}",a);
            }

            int alt = 10;
            while (alt <20)
            {
                Console.WriteLine("Tôi đã đếm đến: {0}",alt);
                alt++;
            }
            Console.WriteLine("----------------------------");

            int atl = 10;
            do
            {
                Console.WriteLine("Tôi đã đếm đến: {0}", atl);
                atl++;
                if (atl == 15)
                {
                    Console.WriteLine("Do giá trị atl = {0} nên chương trình sẽ thoát khỏi vòng lặp", atl);
                    break;
                }
            } while (atl < 20);

        }
    }
}
