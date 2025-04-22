using System;
using System.Collections.Generic;
using ООП10Library;
using ООП12Library;

namespace ООП12
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOne();// добавление одного элемента в коллекцию
            AddMany();// добавление нескольких элементов в коллекцию
            DeleteOne();// удаление одного элемента из коллекции
            DeleteMany();// удаление нескольких элементов из коллекции
            SearchKey();// поиск элемента по значению
            DeepCopy();// глубокое клонирование коллекции
            ShallowCopy();// поверхностное копирования
            DeleteCollection();// удаление коллекции из памяти


            Console.ReadLine();
        }

        static HashTableCollection<string, Goods> goodsHash = new HashTableCollection<string, Goods>();
        static void PrintMenuInfo(string info)
        {

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(info);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        // Метод для добавления товаров в коллекцию
        static public void AddGoodsHashTable(HashTableCollection<string, Goods> goodsHash, Goods[] goods)
        {
            // Создаем список пар ключ-значение
            List<KeyValuePair<string, Goods>> items = new List<KeyValuePair<string, Goods>>();

            foreach (var good in goods)
            {
                // Создаем пару ключ-значение (Goods, Name)
                items.Add(new KeyValuePair<string, Goods>(good.Name, good));
            }

            // Теперь добавляем пары в хеш-таблицу
            goodsHash.AddRange(items);
        }
        // Метод для удаления товаров из коллекции
        static public void DeleteGoodsHashTable(HashTableCollection<string, Goods> goodsHash, Goods[] goods)
        {
            // Создаем список пар ключ-значение
            List<KeyValuePair<string, Goods>> items = new List<KeyValuePair<string, Goods>>();

            foreach (var good in goods)
            {
                // Создаем пару ключ-значение (Goods, Name)
                items.Add(new KeyValuePair<string, Goods>(good.Name, good));
            }

            // Теперь удаляем пары из хеш-таблицы
            goodsHash.RemoveRange(items);
        }
        static void AddOne()
        {
            PrintMenuInfo("Добавление одного элемента в коллекцию");

            Goods goods = new Goods("Диван", 15000, 2);

            goodsHash.Add(goods.Name, goods);
            goodsHash.Print();
        }

        static void AddMany()
        {
            PrintMenuInfo("Добавление нескольких элементов в коллекцию");

            Goods[] goods = new Goods[4];
            goods[0] = new Goods("Гардероб", 20000, 5);
            goods[1] = new Goods("Зеркало", 4000, 3);
            goods[2] = new Goods("Вешалка", 2500, 6);
            goods[3] = new Goods("Пуфик", 3000, 7);

            AddGoodsHashTable(goodsHash, goods);

            goodsHash.Print();

        }
        static void DeleteOne()
        {
            PrintMenuInfo("Удаление одного элемента из коллекции");

            goodsHash.Remove("Диван");

            goodsHash.Print();
        }
        static void DeleteMany()
        {
            PrintMenuInfo("Удаление нескольких элементов из коллекции");

            Goods[] goods = new Goods[2];
            goods[0] = new Goods("Гардероб", 20000, 5);
            goods[1] = new Goods("Зеркало", 4000, 3);

            DeleteGoodsHashTable(goodsHash, goods);

            goodsHash.Print();
        }
        static void SearchKey()
        {
            PrintMenuInfo("Поиск элемента по значению");

            Goods goods = new Goods("Пуфик", 3000, 7);
            if (goodsHash.TryGetValue(goods.Name, out goods))
            {
                Console.WriteLine($"Элемент по значению || {goods} || найден");
            }
            else Console.WriteLine($"Элемент по значению || {goods} || НЕ найден");
        }
        static void DeepCopy()
        {
            PrintMenuInfo("Глубокое клонирование коллекции");

            Console.WriteLine("Коллекция до:");
            goodsHash.Print();
            Console.WriteLine();

            HashTableCollection<string, Goods> goodsHashCopy = new HashTableCollection<string, Goods>();
            goodsHashCopy = goodsHash.DeepClone();

            goodsHash.Remove("Пуфик");

            Console.WriteLine("Коллекция после изменений и глубокого клонирования:");
            goodsHashCopy.Print();
            Console.WriteLine();

            Console.WriteLine("Исходная коллекция:");
            goodsHash.Print();
            Console.WriteLine();
        }
        static void ShallowCopy()
        {
            PrintMenuInfo("Поверхностное копирования");

            Console.WriteLine("Коллекция до:");
            goodsHash.Print();
            Console.WriteLine();

            HashTableCollection<string, Goods> goodsHashCopy = new HashTableCollection<string, Goods>();
            goodsHashCopy = goodsHash.ShallowCopy();

            goodsHash.Remove("Вешалка");

            Console.WriteLine("Коллекция после изменений и поверхностного клонирования:");
            goodsHashCopy.Print();
            Console.WriteLine();

            Console.WriteLine("Исходная коллекция:");
            goodsHash.Print();
            Console.WriteLine();
        }
        static void DeleteCollection()
        {
            PrintMenuInfo("Удаление коллекции из памяти");
            goodsHash.Dispose();
            try
            {
                goodsHash.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
