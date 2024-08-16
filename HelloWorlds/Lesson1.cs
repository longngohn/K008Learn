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
            double baocaoTaiChinhHopNhat = 3000;
            string hovaTen = "Nguyen Van A";

            soCanBo = (int)baocaoTaiChinhHopNhat;

            Console.WriteLine(soCanBo);

            //Kết thúc code

            watch.Stop();

            Console.WriteLine("Thời gian chạy code: " + watch.Elapsed);

            
        }

    }
}
