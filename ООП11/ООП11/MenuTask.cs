using System;
using System.Collections.Generic;
using System.Text;
using MenuLib;

namespace ООП11
{
    class MenuTask
    {
        static public void MainMenu()
        {
            string[] menuItems = {
            "Часть 1. Коллекция",
            "Часть 2. Обобщенная коллекция",
            "Часть 3. Стек"
            };
            int currentIndex = Menu.NavigatingMenu("\nГлавное меню\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    MenuPart1_2(1);
                    break;
                case 1:
                    MenuPart1_2(2);
                    break;
                case 2:
                    MenuPart3();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart1_2(currentIndex + 1);
        }
        static public void MenuPart1_2(int part)
        {
            string[] menuItems = {
            "1. Добавить элемент в коллекцию",
            "2. Удалить элемент из коллекции",
            "3. Печать всех товаров",
            "4. Печать мололочных продуктов",
            "5. Количество мололочных продуктов",
            "6. Общая стоимость всех продуктов",
            "7. Клонировать коллекцию",
            "8. Сортировать коллекцию",
            "9. Поиск игрушки"
            };

            int currentIndex = Menu.NavigatingMenu($"\nЧасть {part}\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    if(part == 1)
                        Part1.AddGoods();
                    else
                        Part2.AddGoods();
                    break;
                case 1:
                    if (part == 1)
                        Part1.DeleteGoods();
                    else
                        Part2.DeleteGoods();
                    break;
                case 2:
                    if (part == 1)
                        Part1.PrintGoods();
                    else
                        Part2.PrintGoods();
                    break;
                case 3:
                    if (part == 1)
                        Part1.PrintMilkProducts();
                    else
                        Part2.PrintMilkProducts();
                    break;
                case 4:
                    if (part == 1)
                        Part1.AmountMilkProducts();
                    else
                        Part2.AmountMilkProducts();
                    break;
                case 5:
                    if (part == 1)
                        Part1.TotalPriceProducts();
                    else
                        Part2.TotalPriceProducts();
                    break;
                case 6:
                    if (part == 1)
                        Part1.Clone();
                    else
                        Part2.Clone();
                    break;
                case 7:
                    if (part == 1)
                        Part1.Sort();
                    else
                        Part2.Sort();
                    break;
                case 8:
                    if (part == 1)
                        Part1.ToySearch();
                    else
                        Part2.ToySearch();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart1_2(part);
        }
        static public void MenuPart3()
        {
            string[] menuItems = {
            "1. Создать коллекцию TestCollections (+1000 элементов)",
            "2. Время поиска в различных коллекциях",
            "3. Вывод элементов коллекций",
            "4. Добавление элемента",
            "5. Удаление элемента"
            };

            int currentIndex = Menu.NavigatingMenu("\nЧасть 3\n", menuItems);

            Console.Clear();
            switch (currentIndex)
            {
                case 0:
                    Part3.СreatureTestCollections();
                    break;
               case 1:
                    Part3.MeasuringTime();
                    break;
                case 2:
                    Part3.PrintTestCollection();
                    break;
                case 3:
                    Part3.AddItem();
                    break;
                case 4:
                    Part3.DelItem();
                    break;
                case -1:
                    MainMenu();
                    break;
            }
            MenuPart3();
        }
    }
}
