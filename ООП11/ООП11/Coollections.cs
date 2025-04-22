using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ООП10Library;

namespace ООП11
{
    public class Coollections 
    {

        public Stack StackCollections { get; set; } // простая коллекция
        public int CountStack
        {
            get
            {
                if (!IsCollectionEmpty())
                    return StackCollections.Count;
                return 0;
            }
        }
        public Coollections()
        {
            StackCollections = new Stack();
        }
        public Coollections(Stack stack)
        {
            StackCollections = stack;
        }

        // Проверка на пустоту коллекции
        private bool IsCollectionEmpty()
        {
            return StackCollections.Count == 0;
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
        public void Add<T>(T goods) where T : Goods
        {
            StackCollections.Push(goods);
        }
        public void AddRandom()
        {
            Goods goods = RandomInit();
            StackCollections.Push(goods);
        }
        public void Delete(int deleteIndex)
        {
            if (IsCollectionEmpty())
                return;

            if (deleteIndex < 0 || deleteIndex >= StackCollections.Count)
            {
                Console.WriteLine("Индекс вне диапазона");
                return;
            }

            // Временный стек для хранения элементов
            Stack tempStack = new Stack();
            int currentIndex = 0;

            // Удаляем элемент по индексу
            while (StackCollections.Count > 0)
            {
                Goods item = (Goods)StackCollections.Pop();
                if (currentIndex != deleteIndex)
                {
                    tempStack.Push((Goods)item); // Сохраняем элементы, кроме удаляемого
                }
                currentIndex++;
            }

            // Переносим элементы обратно в оригинальный стек
            while (tempStack.Count > 0)
            {
                StackCollections.Push(tempStack.Pop());
            }
        }
        public void Print <T>() where T : Goods
        {
            if (IsCollectionEmpty())
                return;
            else
                foreach (var item in StackCollections)
                {
                    if (item is T Tgoods)
                    {
                        Console.WriteLine(Tgoods);
                    }
                }
        }
        public void Sort<T> () where T : Goods
        {
            Stack tempStack = new Stack();

            while (!IsCollectionEmpty())
            {
                // Извлечение элемента из стека
                object item = StackCollections.Pop();
                T currentItem = item as T; // Приведение с использованием 'as'
                if (currentItem != null)
                    while (tempStack.Count > 0 && currentItem.CompareTo(tempStack.Peek()) == -1)
                    {
                        StackCollections.Push(tempStack.Pop());
                    }

                tempStack.Push(currentItem);
            }

            while (tempStack.Count > 0)
            {
                StackCollections.Push(tempStack.Pop());
            }
        }
        public bool Search<T>(T itemToFind) where T : Goods
        {
            Stack tempStack = new Stack();
            bool found = false;

            while (!IsCollectionEmpty())
            {
                T currentItem = (T)StackCollections.Pop();

                if (currentItem.Equals(itemToFind))
                {
                    found = true;
                }

                tempStack.Push(currentItem);
            }

            while (tempStack.Count > 0)
            {
                StackCollections.Push(tempStack.Pop());
            }

            return found;
        }
        public int AmountTypeGoods<T> () where T : Goods
        {
            int sum = 0;
            if (IsCollectionEmpty())
                return 0;
            else
            {
                foreach (var item in StackCollections)
                {
                    if (item is T Tgoods)
                    {
                        sum++;
                    }

                }
            }
            
            return sum;
        }
        public decimal TotalPriceGoods<T>() where T : Goods
        {
            decimal totalPrice = 0;
            if (IsCollectionEmpty())
                return 0;
            else
            {
                foreach (var item in StackCollections)
                {
                    if (item is T Tgoods)
                    {
                        totalPrice += ((T)item).Price;
                    }

                }
            }

            return totalPrice;
        }
        public virtual object Clone()
        {
            Coollections clone = new Coollections();
            if (StackCollections.Count == 0)
            {
                return clone;
            }    
            foreach (Goods goods in StackCollections)
            {
                clone.StackCollections.Push((Goods)goods.Clone());
            }
            return clone;
        }
    }
}
