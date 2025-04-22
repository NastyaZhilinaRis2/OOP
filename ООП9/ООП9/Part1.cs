using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class Part1
    {
        static public Time time1, time2;
        static public void First()
        {

            time1 = new Time();
            time2 = new Time();

            Console.WriteLine("\nСоздание двух объектов типа Time\n");

            Console.WriteLine("Ввод time1\n");
            Time.InputTime(time1);

            Console.WriteLine("\nВвод time2\n");
            Time.InputTime(time2);

            Help.keyESC();
        }
        static public void Second()
        {
            if (time1 == null && time2 == null)
                Console.WriteLine($"\nСоздайте времена!\n");
            else
            {
                Console.WriteLine("\nВывод времен\n");
                Console.Write($"time1: {time1}\n");
                Console.Write($"time2: {time2}\n");
            }

            Help.keyESC();
        }
        static public void Third()
        {
            if (time1 == null || time2 == null)
                Console.WriteLine($"\nСоздайте времена!\n");
            else
            {
                Console.WriteLine("\nРазность первого и второго времен\n");
                Console.Write($"time1: {time1}\n");
                Console.Write($"time2: {time2}\n");
                try
                {
                    Console.WriteLine($"\nИтог статической функцией: {Time.SubtractingSecondFromFirstStatic(time1, time2)}");
                    Time time = new Time(time1);
                    Console.WriteLine($"\nИтог методом: {time.SubtractingSecondFromFirstMethod(time2)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            Help.keyESC();
        }

    }
}
