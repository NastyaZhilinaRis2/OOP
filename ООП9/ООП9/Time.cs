using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class Time
    {
        public static int count;
        private int hours, minutes; 
        private int Hours 
        { 
            get 
            { 
                return hours;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Часы не могут быть отрицательными.");

                if (value < 24)
                    hours = value;
                else
                    throw new ArgumentOutOfRangeException("Ошибка: Неверный ввод часов. Значение должно быть меньше 24.");
            }
        }
        private int Minutes
        {
            get { return minutes; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Минуты не могут быть отрицательными.");
                if (value < 60)
                    minutes = value;
                else
                    throw new ArgumentOutOfRangeException("Ошибка: Неверный ввод минут. Значение должно быть меньше 60.");
            }
        }

        public Time()
        {
            Hours = 0;
            Minutes = 0;
            count++;
        }
        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            count++;
        }
        public Time(Time time)
        {
            Hours = time.hours;
            Minutes = time.minutes;
            count++;
        }
        public int GetHours()
        {
            return Hours;
        }
        public int GetMinuts()
        {
            return Minutes;
        }
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }
        public static implicit operator int (Time time) 
        {
            return time != null ? time.hours * 60 + time.minutes : 0;
        }
        public static explicit operator bool (Time time)
        {
            return time != null && (time.hours != 0 || time.minutes != 0);
        }
        public static bool operator <(Time time1, Time time2)
        {
            if (time1 == null || time2 == null)
                throw new ArgumentNullException("Ошибка: сравнение времен невозможно. time не создан(ы)");
            else
                return (int)time1 < (int)time2;
        }
        public static bool operator >(Time time1, Time time2)
        {
            if (time1 == null || time2 == null)
                throw new ArgumentNullException("Ошибка: сравнение времен невозможно. time не создан(ы)");
            else
                return (int)time1 > (int)time2;
        }
        public static Time operator --(Time time)
        {
            if (time == null)
                throw new ArgumentNullException("Ошибка: операция декремента невозможна. time не создан");
            int totalMinutes = (int)time;

            if (totalMinutes > 0)
                return ConversionIntoHoursMinutes(totalMinutes - 1);
            else
            {
                count--;
                return new Time(23, 59);
            }
        }
        public static Time operator ++(Time time)
        {
            if (time == null)
                throw new ArgumentNullException("Ошибка: операция инкремента невозможна. time не создан");

            int totalMinutes = (int)time;

            if (totalMinutes != 23*60+59)
                return ConversionIntoHoursMinutes(totalMinutes + 1);
            else
            {
                count--;
                return new Time(0, 0);
            }
        }
        public static Time ConversionIntoHoursMinutes(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            count--;
            return new Time(hours, minutes);
        }
        public static Time SubtractingSecondFromFirstStatic(Time time1, Time time2)
        {
            if (time1 == null || time2 == null)
                throw new ArgumentNullException("Ошибка: невозможно произвести операцию. time не создан(ы)");
            if (time1 < time2)
                throw new InvalidOperationException("Ошибка: невозможно произвести операцию. time1 < time2");
            else
            {
                int minutes = (int)(time1) - (int)(time2);
                count--;
                Time time = new Time(ConversionIntoHoursMinutes(minutes));
                return time;
            }
        }
        public Time SubtractingSecondFromFirstMethod(Time time2)
        {
            if (this == null || time2 == null)
                throw new ArgumentNullException("Ошибка: невозможно произвести операцию. time не создан(ы)");
            if (this < time2)
                throw new InvalidOperationException("Ошибка: невозможно произвести операцию. time1 < time2");
            else 
            {
                int minutes = (int)(this) - (int)(time2);
                count--;
                Time time = new Time(ConversionIntoHoursMinutes(minutes));
                return time;
            }
        }
        static public void InputTime(Time time)
        {
            if (time == null)
                throw new ArgumentNullException("Ошибка: Невозможно ввести time. Объект time не создан");
            do
            {
                try
                {
                    Console.Write("Введите часы: ");
                    time.Hours = Help.InputInt();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
            do
            {
                try
                {
                    Console.Write("Введите минуты: ");
                    time.Minutes = Help.InputInt();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
        }
    }
}
