using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    class Part2
    {
        static public void First()
        {
            if(Part1.time1 == null || Part1.time2 == null)
                Console.WriteLine($"\nСоздайте времена!\n");
            else
            {
                Console.WriteLine($"\ntime1: {Part1.time1}");
                Console.WriteLine($"time2: {Part1.time2}");

                Console.WriteLine($"\nУнарные операции:\n");
                Console.WriteLine($"++ к time1: {++Part1.time1}");
                Console.WriteLine($"-- к time1: {--Part1.time1}\n");
                Console.WriteLine($"++ к time2: {++Part1.time2}");
                Console.WriteLine($"-- к time2: {--Part1.time2}");

                Console.WriteLine($"\nПриведение типов:\n");
                Console.WriteLine($"time1 в минутах: {(int)Part1.time1}");
                Console.WriteLine($"time1 != 00:00 ? {(bool)Part1.time1}\n");
                Console.WriteLine($"time2 в минутах: {(int)Part1.time2}");
                Console.WriteLine($"time2 != 00:00 ? {(bool)Part1.time2}");

                Console.WriteLine($"\nРабота операторов > и <:\n");
                if (Part1.time1 > Part1.time2)
                    Console.WriteLine("time1 > time2");
                else if (Part1.time1 < Part1.time2)
                    Console.WriteLine("time2 > time1");
                else
                    Console.WriteLine("time1 = time2");
            }
            

            Help.keyESC();
        }
        static public void Second()
        {
            Console.WriteLine($"\nКоличество созданных объектов: {Time.count}\n");
            Help.keyESC();
        }
    }
}
