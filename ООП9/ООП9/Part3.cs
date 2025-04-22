using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    class Part3
    {
        public static TimeArray timeArray;
        static public void First()
        {
            Console.WriteLine("\nСоздание массива объектов Time со случайными значениями:\n");
            Console.Write("Введите размер массива: ");
            int size = Help.InputInt(1, 10);

            timeArray = new TimeArray(size, true);
            Help.keyESC();
        }
        static public void Second()
        {
            Console.WriteLine("\nСоздание массива объектов Time с пользовательским вводом:\n");
            Console.Write("Введите размер массива: ");
            int size = Help.InputInt(1, 10);
            timeArray = new TimeArray(size);

            Help.keyESC();
        }
        static public void Third()
        {
            if (timeArray == null)
            {
                Console.WriteLine("\nМассив пуст!\n");
            }
            else
                Console.WriteLine($"\nВывод массива объектов Time:\n{timeArray}");

            Help.keyESC();
        }
        static public void Fourth()
        {
            int index;
            if(timeArray == null)
            {
                Console.WriteLine("\nМассив пуст!\n");
            }
            else
            {
                Console.WriteLine("\nРабота индексатора:\n");
                do
                {
                    try
                    {
                        Console.Write("Введите индекс элемента, в котором будет установлено время 12:00: ");
                        index = Help.InputInt();
                        // Установка значений через индексатор
                        timeArray[index] = new Time(12, 00);
                        break;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (true);

                do
                {
                    try
                    {
                        Console.Write("\nВведите индекс элемента, который необходимо вывести: ");
                        index = Help.InputInt();
                        // Получение значений через индексатор
                        Console.WriteLine(timeArray[index].ToString());
                        break;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (true);
                
            }

            Help.keyESC();
        }
        static public void Fifth()
        {
            if (timeArray == null)
            {
                Console.WriteLine("\nМассив пуст!\n");
            }
            else
            {
                Console.WriteLine($"\nВывод массива объектов Time:\n{timeArray}");
                Console.WriteLine("Максимальный элемент в массиве:");
                Console.WriteLine(timeArray.MaxTime().ToString());
            }

            Help.keyESC();
        }
    }
}
