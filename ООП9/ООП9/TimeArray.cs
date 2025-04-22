using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class TimeArray
    {
        private Time[] arr;//одномерный массив элементов типа Time

        public TimeArray()//конструтор без параметров
        {
            arr = new Time[0];
        }
        public TimeArray(int size)//конструтор с параметром для пользовательского ввода данных
        {
            arr = new Time[size];
            Console.WriteLine("\nВведите элементы массива:\n");
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Time();
                Console.WriteLine($"{i+1} время: ");
                Time.InputTime(arr[i]);
                Console.WriteLine();
            }
        }
        public TimeArray(int size, bool auto)//конструтор с параметром для рандомного ввода данных
        {
            Random random = new Random();
            int hour, minutes;
            arr = new Time[size];
            for (int i = 0; i < size; i++)
            {
                hour = random.Next(0,24);
                minutes = random.Next(0,60);
                arr[i] = new Time(hour, minutes);
            }
        }
        public Time this[int index]// Индексатор
        {
            get
            {
                if (arr == null)
                    throw new InvalidOperationException("Массив не инициализирован.");
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс вне диапазона.\n");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс вне диапазона.\n");
                arr[index] = value;
            }
        }
        public int Length
        {
            get { return arr.Length; }
        }
        public override string ToString()
        {
            if (arr.Length <= 0)
                throw new ArgumentException("Массив пуст");

            string times = "";
            for (int i = 0; i < arr.Length; i++)
            {
                times += arr[i] + "\n";
            }
            return times;
        }
        public Time MaxTime()
        {
            if (this.arr.Length == 0)
                throw new InvalidOperationException("Массив пуст, невозможно найти максимальное время.");

            Time maxTime = this.arr[0];
            for (int i = 1; i < this.arr.Length; i++)
            {
                if (maxTime < this.arr[i])
                    maxTime = this.arr[i];
            }
            return maxTime;
        }
    }
}
