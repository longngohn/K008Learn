using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorlds
{
    [TestFixture]
    internal class SwitchCase
    {
        [Test]
        public void Switch()
        {
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
        }
    }
}
