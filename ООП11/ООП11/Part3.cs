using MenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ООП10Library;

namespace ООП11
{
    class Part3
    {
        static TestCollections test;
        static public bool IsCollectionEmpty()
        {
            return test == null;
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
        public static void СreatureTestCollections()
        {
            test = new TestCollections();
            Console.WriteLine("TestCollections создана!");
            Menu.keyESC();
        }
        public static void PrintTestCollection()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            foreach (var item in test.listProduct)
                Console.WriteLine(item);

            Menu.keyESC();
        }

        public static void DelItem()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            var product = new Product();
            product.BaseGoods.Init();
            if (test.Delete(product))
                Console.WriteLine("Продукт удален.");
            else
                Console.WriteLine("Такого продукта нет.");
            Menu.keyESC();
        }

        public static void AddItem()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            var product = new Product();
            product.Init();
            if (test.Add(product))
                Console.WriteLine("Продукт добавлен.");
            else
                Console.WriteLine("Не удалось добавить продукт.");
            Menu.keyESC();
        }
        public static T GetCenterValue<T>(LinkedList<T> list)
        {
            int center = list.Count / 2;
            var item = list.First;
            for (int i = 0; i < center; i++)
                item = item.Next;
            return item.Value;
        }
        static public void MeasuringTime()
        {
            if (IsCollectionEmpty())
            {
                PrintCollectionEmpty();
                return;
            }
            Console.WriteLine("Поиск первого элемента в коллекции LinkedList<Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listProduct, (Product)test.listProduct.First.Value.Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции LinkedList<Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listProduct, (Product)GetCenterValue(test.listProduct).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции LinkedList<Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listProduct, (Product)test.listProduct.Last.Value.Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию LinkedList<Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listProduct, new Product())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции LinkedList<string>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listStr, (string)test.listStr.First.Value.Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции LinkedList<string>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listStr, (string)GetCenterValue(test.listStr).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции LinkedList<string>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listStr, (string)test.listStr.Last.Value.Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию LinkedList<string>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkList(test.listStr, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции Dictionary<Goods,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyGoods, (Goods)test.dictionaryKeyGoods.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции Dictionary<Goods,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyGoods, (Goods)test.dictionaryKeyGoods.Keys.ToArray()[test.dictionaryKeyGoods.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции Dictionary<Goods,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyGoods, (Goods)test.dictionaryKeyGoods.Keys.ToArray()[test.dictionaryKeyGoods.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию Dictionary<Goods,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyGoods, new Goods())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (string)test.dictionaryKeyStr.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (string)test.dictionaryKeyStr.Keys.ToArray()[test.dictionaryKeyStr.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (string)test.dictionaryKeyStr.Keys.ToArray()[test.dictionaryKeyStr.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (Product)test.dictionaryKeyStr.Values.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (Product)test.dictionaryKeyStr.Values.ToArray()[test.listProduct.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, (Product)test.dictionaryKeyStr.Values.ToArray()[test.listProduct.Count - 1].Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию Dictionary<string,Product>...");
            Console.WriteLine($"Время = {TimeWork.TimeOfWorkDictionary(test.dictionaryKeyStr, new Product())}");

            Menu.keyESC();
        }

    }
}
