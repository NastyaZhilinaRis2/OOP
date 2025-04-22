using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ООП10Library;

namespace ООП11
{
    public class GeneralizedCollection
    {

        public List<Goods> ListCollections { get; set; } // обобщенная коллекция
        public int CountListCollections
        {
            get
            {
                if (!IsCollectionEmpty())
                    return ListCollections.Count;
                return 0;
            }
        }
        public GeneralizedCollection()
        {
            ListCollections = new List<Goods>();
        }
        public GeneralizedCollection(List<Goods> goods)
        {
            ListCollections = goods;
        }
        // Проверка на пустоту коллекции
        private bool IsCollectionEmpty()
        {
            return ListCollections == null;
        }
        // Метод для генерации случайного товара
        public Goods RandomInit()
        {
            Random random = new Random();
            int goodsType = random.Next(3);
            switch (goodsType)
            {
                case 0:// игрушки
                    {
                        Toy toy = new Toy();
                        toy.RandomInit();
                        return toy;
                    }
                case 1:// продукты
                    {
                        Product product = new Product();
                        product.RandomInit();
                        return product;
                    }
                case 2:// молочка
                    {
                        MilkProduct milkProduct = new MilkProduct();
                        milkProduct.RandomInit();
                        return milkProduct;
                    }
                default:
                    throw new Exception("Нет такого типа");
            }
        }
        public void AddRandom()
        {
            Goods goods = RandomInit();
            ListCollections.Add(goods);
        }
        public void Add<T>(T goods) where T : Goods
        {
            ListCollections.Add(goods);
        }
        public void Delete(int deleteIndex)
        {
            if (IsCollectionEmpty())
                return;
            if (CountListCollections == 0)
                return;
            ListCollections.RemoveAt(deleteIndex);
        }
        public void Print<T>() where T : Goods
        {
            if (IsCollectionEmpty())
                return;
            foreach (var item in ListCollections)
            {
                if (item is T Tgoods)
                {
                    Console.WriteLine(Tgoods);
                }

            }

        }
        public void Sort()
        {
            ListCollections.Sort();
        }
        public bool SearchInList(Goods itemToFind)
        {
            if (IsCollectionEmpty())
                return false;
            foreach (object item in ListCollections)
            {
                if (item.Equals(itemToFind))
                {
                    return true;
                }
            }
            return false;
        }

        public int AmountType<T>() where T : Goods
        {
            int amount = 0;
            if (IsCollectionEmpty())
                return 0;
            foreach (var item in ListCollections)
            {
                if (item is T Tgoods)
                {
                    amount++;
                }

            }

            return amount;
        }
        public decimal TotalPrice<T>() where T : Goods
        {
            decimal totalPrice = 0;
            if (IsCollectionEmpty())
                return 0;
            foreach (var item in ListCollections)
            {
                if (item is T Tgoods)
                {
                    totalPrice += item.Price;
                }
            }

            return totalPrice;
        }
        public object Clone()
        {
            GeneralizedCollection clone = new GeneralizedCollection();
            if (ListCollections.Count == 0)
                return clone;
            foreach (var item in ListCollections)
            {
                clone.ListCollections.Add((Goods)(item.Clone()));
            }
            return clone;
        }
    }
}
