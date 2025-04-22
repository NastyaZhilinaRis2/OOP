using System;
using System.Collections.Generic;
using System.Text;

namespace ООП10Library
{
    public class UserInput
    {
        public static T InputNumber<T>(Func<string, T> parseFunc, T? left = null, T? right = null) where T : struct
        {
            T number;

            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    // Попытка парсинга ввода
                    if (parseFunc(input) is T parsedNumber)
                    {
                        number = parsedNumber;

                        // Проверка на диапазон, если он задан
                        if ((left == null || Comparer<T>.Default.Compare(number, left.Value) >= 0) &&
                            (right == null || Comparer<T>.Default.Compare(number, right.Value) <= 0))
                        {
                            return number; // Возвращаем корректное число
                        }

                        // Сообщение о неверном диапазоне
                        if (left != null && right != null)
                        {
                            Console.WriteLine($"Введите число из интервала от {left} до {right}");
                        }
                        else if (left != null)
                        {
                            Console.WriteLine($"Введите число больше или равно {left}");
                        }
                        else if (right != null)
                        {
                            Console.WriteLine($"Введите число меньше или равно {right}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Введите число: ");
                    }
                }
                catch (Exception ex)
                {
                    // Обработка исключений
                    Console.WriteLine($"Произошла ошибка: {ex.Message}. Пожалуйста, попробуйте снова.");
                }
            }
        }
        public static string InputString()
        {
            string str;
            do
            {
                str = Console.ReadLine();
                if (str == null)
                    Console.WriteLine("Введите не пустую строку!");
                else
                    break;
            } while (true);
            return str;
        }
    }
}
