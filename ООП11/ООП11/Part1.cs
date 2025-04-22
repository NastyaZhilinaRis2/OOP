using System;
using System.Text;
using ООП10Library;
using MenuLib;

namespace ООП11
{
    class Part1
    {

        static Coollections coolections;

        // Проверка на пустоту коллекции

        static public bool IsCollectionEmpty()
        {
            return coolections == null;
        }
        static public void PrintCollectionEmpty()
        {
            bool empty = IsCollectionEmpty();
            if (empty)
            {
                Console.WriteLine("Коллекция = null.");
                Menu.keyESC();
            }
        }
        static public void AddGoods()
        {
            coolections = new Coollections();
            Console.WriteLine("Введите количество элементов (2-10)");
            int size = UserInput.InputNumber<int>(int.Parse, 2, 10);

            for (int i = 0; i < size; i++)
            {
                coolections.AddRandom();
            }

            coolections.Add(new Toy("Трамвай", 500, 1000, "Детский мир", 0));
            Console.WriteLine("Элементы добавлены!");
            Menu.keyESC();
        }
        static public void DeleteGoods()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Random random = new Random();
            
            int deleteIndex = random.Next(0, coolections.CountStack);

            Console.WriteLine($"Удален элемент под индексом {deleteIndex}");

            coolections.Delete(deleteIndex);
            Menu.keyESC();
        }
        static public void PrintGoods()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Перебор всех товаров в коллекции с помощью foreach:");
            coolections.Print<Goods>();
            Menu.keyESC();
        }
        static public void PrintMilkProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Перебор мололочных продуктов в коллекции с помощью foreach:");
            coolections.Print<MilkProduct>();
            Menu.keyESC();
        }

        static public void AmountMilkProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Количество мололочных продуктов в коллекции с помощью foreach:");
            Console.WriteLine(coolections.AmountTypeGoods<MilkProduct>());
            Menu.keyESC();
        }

        static public void TotalPriceProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Общая стоимость всех продуктов в коллекции с помощью foreach:");
            Console.WriteLine(coolections.TotalPriceGoods<Product>());
            Menu.keyESC();
        }

        static public void Clone()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Coollections clone = (Coollections)coolections.Clone();
            Console.WriteLine("Клон:");
            clone.Print<Goods>();
            Console.WriteLine("Удалим в оригинале строку с индексом 0");
            coolections.Delete(0);
            Console.WriteLine("Оригинал:");
            coolections.Print<Goods>();
            Console.WriteLine("Клон:");
            clone.Print<Goods>();

            Menu.keyESC();
        }
        static public void Sort()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Сортированная коллекция:");
            coolections.Sort<Goods>();
            coolections.Print<Goods>();
            Menu.keyESC();
        }
        static public void ToySearch()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            coolections.Sort<Goods>();
            Toy toy_search = new Toy("Трамвай", 500, 1000, "Детский мир", 0);
            bool found = coolections.Search<Goods>(toy_search);

            if (found)
            {
                Console.WriteLine($"Строка {toy_search.ToString().Trim()} найдена!");
            }
            else
            {
                Console.WriteLine($"Строка {toy_search.ToString().Trim()} не найдена!");
            }
                
            Menu.keyESC();
        }
    }
}
