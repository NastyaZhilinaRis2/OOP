using System;
using System.Text;
using ООП10Library;
using MenuLib;

namespace ООП11
{
    class Part2
    {

        static GeneralizedCollection generalCoolections;
        // Проверка на пустоту коллекции

        static public bool IsCollectionEmpty()
        {
            return generalCoolections == null;
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
            generalCoolections = new GeneralizedCollection();
            Console.WriteLine("Введите количество элементов (2-10)");
            int size = UserInput.InputNumber<int>(int.Parse, 2, 10);

            for (int i = 0; i < size; i++)
            {
                generalCoolections.AddRandom();
            }

            generalCoolections.Add(new Toy("Трамвай", 500, 1000, "Детский мир", 0));
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

            int deleteIndex = random.Next(0, generalCoolections.CountListCollections);

            Console.WriteLine($"Удален элемент под индексом {deleteIndex}:");

            generalCoolections.Delete(deleteIndex);
            Menu.keyESC();
        }
        static public void PrintGoods()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Перебор всех товаров в обобщенной коллекции с помощью foreach:");
            generalCoolections.Print<Goods>();
            Menu.keyESC();
        }
        static public void PrintMilkProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Перебор мололочных продуктов в обобщенной коллекции с помощью foreach:");
            generalCoolections.Print<MilkProduct>();
            Menu.keyESC();
        }

        static public void AmountMilkProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Количество мололочных продуктов в обобщенной коллекции с помощью foreach:");
            Console.WriteLine(generalCoolections.AmountType<MilkProduct>());
            Menu.keyESC();
        }

        static public void TotalPriceProducts()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Общая стоимость всех продуктов в обобщенной коллекции с помощью foreach:");
            Console.WriteLine(generalCoolections.TotalPrice<Product>());
            Menu.keyESC();
        }

        static public void Clone()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            GeneralizedCollection clone = (GeneralizedCollection)generalCoolections.Clone();
            Console.WriteLine("Клон:");
            clone.Print<Goods>();
            Console.WriteLine("Удалим в оригинале строку с индексом 0");
            generalCoolections.Delete(0);
            Console.WriteLine("Оригинал:");
            generalCoolections.Print<Goods>();
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
            Console.WriteLine("Сортированная обобщенная коллекция:");
            generalCoolections.Sort();
            generalCoolections.Print<Goods>();
            Menu.keyESC();
        }
        static public void ToySearch()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            generalCoolections.ListCollections.Sort();
            Toy toy_search = new Toy("Трамвай", 500, 1000, "Детский мир", 0);
            bool found = generalCoolections.SearchInList(toy_search);

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
