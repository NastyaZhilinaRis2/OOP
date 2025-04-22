using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLib
{

    static public class Menu
    {
        static public int NavigatingMenu(string nameMenu, string[] menuItems)
        {
            int currentIndex = 0; // Индекс текущего выделенного элемента
            ConsoleKeyInfo key;
            bool isOut = false;
            do
            {
                Console.Clear(); // Очищаем консоль перед перерисовкой меню
                Console.WriteLine(nameMenu);
                // Выводим элементы меню
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == currentIndex) // Если это текущий элемент
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Устанавливаем цвет выделения
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor(); // Сбрасываем цвет
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                key = Console.ReadKey(true); // Читаем нажатую клавишу

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentIndex > 0) // Если не на первом элементе
                        {
                            currentIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentIndex < menuItems.Length - 1) // Если не на последнем элементе
                        {
                            currentIndex++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            isOut = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            isOut = true;
                            currentIndex = -1;
                        }
                        break;
                }
            }
            while (!isOut); // Завершаем цикл по нажатию Enter
            return currentIndex;
        }
        public static void keyESC()
        {
            Console.Write("\nНажмите ESC для выхода");
            ConsoleKeyInfo key;
            do
                key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape);
        }
    }
}
