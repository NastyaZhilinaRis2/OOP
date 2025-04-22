using System;
using ООП10Library;

namespace ООП10
{
    class Program
    {
        static Goods[] goods;
        static void Main(string[] args)
        {
            FirstPart();
            SecondPart();
            ThirdPert();

            Console.ReadLine();
        }
        static void FirstPart()
        {
            Console.WriteLine("Введите размер массива (2-10)");
            int size = UserInput.InputNumber<int>(int.Parse, 2, 10);

            goods = new Goods[size];

            // Генерируем 10 случайных товаров
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i] = GenerateRandomGoods();
            }
            PrintMenuInfo("Товары в массиве с помощью НЕвиртуальной функции:");
            // Просматриваем массив и выводим информацию о каждом товаре
            int number = 1;
            foreach (Goods good in goods)
            {
                PrintGoodsInfo(good, ref number);
                good.ShowNotVirtual();
                Console.WriteLine();
            }

            PrintMenuInfo("Товары в массиве с помощью виртуальной функции:");
            // Просматриваем массив и выводим информацию о каждом товаре
            number = 1;
            foreach (Goods good in goods)
            {
                PrintGoodsInfo(good, ref number);
                good.Show();
                Console.WriteLine();
            }
        }
        static void SecondPart()
        {
            Console.WriteLine("ЗАПРОСЫ");
           
            PrintMenuInfo("1 запрос: Самая дорогая и самая дешевая игрушка в магазине(наименование и стоимость)");
            Toy maxToy = null, minToy = null;
            foreach (Goods good in goods)
            {
                if (good is Toy toy)
                {
                    if (maxToy == null && minToy == null)
                    {
                        maxToy = toy;
                        minToy = toy;
                    }
                    else
                    {
                        if (toy.Price > maxToy.Price)
                            maxToy = toy;
                        else if (toy.Price < minToy.Price)
                            minToy = toy;
                    }
                }
            }

            Console.WriteLine("Самая дорогая: " + maxToy.Name + ", " + maxToy.Price + " руб.");
            Console.WriteLine("Самая дешевая: " + minToy.Name + ", " + minToy.Price + " руб.");
            Console.WriteLine();

            PrintMenuInfo("2 запрос: Суммарная стоимость объекта(ов) типа Product");
            decimal sumProducts = 0;

            foreach (Goods good in goods)
            {
                if (good is Product product) sumProducts += product.Price;
            }
            Console.WriteLine(sumProducts + " руб.");
            Console.WriteLine();

            PrintMenuInfo("3 запрос: Количество товара типа MilkProduct");
            int countMilkProduct = 0;

            foreach (Goods good in goods)
            {
                if (good is MilkProduct) countMilkProduct++;
            }

            Console.WriteLine(countMilkProduct + " шт.");
            Console.WriteLine();

        }
        static void ThirdPert()
        {
            Console.WriteLine("СОРТИРОВКА МАССИВОВ:");

            Toy[] toys = new Toy[6];

            toys[0] = new Toy("Слоненок", 500, 1000, "Детский мир", 0);
            toys[1] = new Toy("Слоненок", 300, 1000, "Детский мир", 3);
            toys[2] = new Toy("Слоненок", 200, 1500, "Детский мир", 0);
            toys[3] = new Toy("Матрешка", 500, 1000, "Hasbro", 0);
            toys[4] = new Toy("Медвежонок", 1000, 500, "Funko", 6);
            toys[5] = new Toy("Медвежонок", 1000, 500, "Детский мир", 0);

            // Выведем созданный массив
            Console.WriteLine("Массив исходный:");
            foreach (Toy toy in toys)
            {
                Console.WriteLine(toy.ToString());
            }

            PrintMenuInfo("Сортировка с помощью IComparer:");
            // Сортировка по цене с помощью IComparer
            Array.Sort(toys, new SortByPrice());

            Console.WriteLine("Массив отсортированный по цене:");

            foreach (Toy toy in toys)
            {
                Console.WriteLine(toy.ToString());
            }


            PrintMenuInfo("Сортировка с помощью IComparable:");
            // Сортировка с помощью IComparable
            Array.Sort(toys);

            Console.WriteLine("Массив отсортированный:");

            foreach (Toy toy in toys)
            {
                Console.WriteLine(toy.ToString());
            }
            // Бинарный поиск
            PrintMenuInfo("Бинарный поиск:");

            Toy toy_search = new Toy("Слоненок", 500, 1000, "Детский мир", 0);
            Console.WriteLine("Найдем строку с параметрами: Слоненок, 500, 1000, Детский мир, 0");
            int index = BinarySearch(toys, toy_search);

            if (index != -1)
                Console.WriteLine($"Строка найдена на индексе: {index}");
            else
                Console.WriteLine("Строка не найдена!");

            // Работа с классом не из иерархии
            PrintMenuInfo("Работа с классом не из иерархии:");
            IInit[] mas = new IInit[]
            {
                    new Toy(),
                    new Product(),
                    new ClassNotHierarchy()
            };
            int number = 1;
            // Инициализация и случайная инициализация
            foreach (var item in mas)
            {
                if (item is Goods good)
                    PrintGoodsInfo(good, ref number);
                else Console.WriteLine(number + ". Неиерархический класс");

                item.Init();
                Console.WriteLine();
                Console.WriteLine("После заполнения Init:\n" + item);
                item.RandomInit();
                Console.WriteLine("После заполнения RandomInit:\n" + item);
                Console.WriteLine();
            }

            // Клонирование
            Goods originalToyn = new Goods("Рыбка", 100, 50);

            // Поверхностное копирование
            Goods shallowCopiedToy = (Goods)originalToyn.ShallowCopy();

            // Клонирование (глубокое копирование)
            Goods clonedPerson = (Goods)originalToyn.Clone();

            originalToyn.ReferenceType[0] = 111;
            originalToyn.Name = "Львенок";

            // Выводим результаты
            Console.WriteLine("Оригинальный объект:");
            Console.WriteLine(originalToyn.StringWithReferenceType());

            Console.WriteLine("\nПоверхностно скопированный объект:");
            Console.WriteLine(shallowCopiedToy.StringWithReferenceType());

            Console.WriteLine("\nКлонированный объект:");
            Console.WriteLine(clonedPerson.StringWithReferenceType());
        }
        static int BinarySearch<T> (T[] mas, T search) where T : IComparable
        {
            int left = 0;
            int right = mas.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Сравниваем средний элемент с искомым
                int comparison = search.CompareTo(mas[mid]);
                if (comparison == 0)
                {
                    return mid; // Элемент найден
                }
                else if (comparison < 0)
                {
                    right = mid - 1; // Ищем в левой половине
                }
                else
                {
                    left = mid + 1; // Ищем в правой половине
                }
            }

            return -1; // Элемент не найден
        }
        static void PrintMenuInfo(string info)
        {

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(info);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
        static void PrintGoodsInfo(Goods good, ref int number)
        {
            Console.Write((number++).ToString() + ". ");
            if (good is Toy)
                Console.WriteLine("Игрушка");
            else if (good is MilkProduct)
                Console.WriteLine("Молочный продукт");
            else if (good is Product)
                Console.WriteLine("Продукт");
        }

            // Метод для генерации случайного товара
            static Goods GenerateRandomGoods()
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
                    throw new Exception("Неверный тип");
            }
        }

    }
}
