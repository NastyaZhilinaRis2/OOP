using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
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
                        Console.ForegroundColor = ConsoleColor.Yellow; // Устанавливаем цвет выделения
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor(); // Сбрасываем цвет
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                key = Console.ReadKey(); // Читаем нажатую клавишу

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
    
        static public void MainMenu()
        {
            string[] menuItems = {
            "Часть 1: Создание объектов типа Time, вывод атрибутов и вычитание объектов Time",
            "Часть 2: Унарные операции, приведение типов, работа операторов < и > и вывод созданного количества объектов",
            "Часть 3: Работа с классом-коллекцией"
            };
            int currentIndex = NavigatingMenu("\nГЛАВНОЕ МЕНЮ\n", menuItems);
            switch (currentIndex)
            {
                case 0:
                    MenuPart1();
                    break;
                case 1:
                    MenuPart2();
                    break;
                case 2:
                    MenuPart3();
                    break;
                case -1:
                    Environment.Exit(0);
                    break;
            }
        }
        static public void MenuPart1()
        {
            string[] menuItems = {
            "Создание двух объектов типа Time",
            "Вывод времен на экран",
            "Вычитание второго времени из первого статической функцией и методом"
            };
            int currentIndex = NavigatingMenu("\nЧасть 1\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    Part1.First();
                    break;
                case 1:
                    Part1.Second();
                    break;
                case 2:
                    Part1.Third();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart1();
        }
        static public void MenuPart2()
        {
            string[] menuItems = {
            "Демонстрация операций",
            "Вывод кол-ва созданных объектов типа Time",
            };
            int currentIndex = NavigatingMenu("\nЧасть 2\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    Part2.First();
                    break;
                case 1:
                    Part2.Second();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart2();
        }
        static public void MenuPart3()
        {
            string[] menuItems = {
            "Создание массива объектов Time со случайными значениями",
            "Создание массива объектов Time с пользовательским вводом",
            "Вывод массива объектов Time на экран",
            "Демонстрация использования индексатора для доступа к элементам массива",
            "Поиск максимального значения"
            };
            int currentIndex = NavigatingMenu("\nЧасть 3\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    Part3.First();
                    break;
                case 1:
                    Part3.Second();
                    break;
                case 2:
                    Part3.Third();
                    break;
                case 3:
                    Part3.Fourth();
                    break;
                case 4:
                    Part3.Fifth();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart3();
        }

    }
}
