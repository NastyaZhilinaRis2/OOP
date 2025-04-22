using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ООП10Library;
using ООП12Library;

namespace ООП14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Dictionary<int, Goods>> store = new Queue<Dictionary<int, Goods>>();

            ///////////////// ЗАПОЛНЕНИЕ КОЛЛЕКЦИЙ
            #region ЗАПОЛНЕНИЕ КОЛЛЕКЦИЙ
            PrintMenuLevel1("1. Коллекция:");

            Dictionary<int, Toy> toyDepartment = new Dictionary<int, Toy>();
            toyDepartment.Add(1, new Toy("Жираф", 1500, 100, "B.Toys", 6));
            toyDepartment.Add(2, new Toy("Слон", 100, 50, "Classic World", 6));
            toyDepartment.Add(3, new Toy("Машинка", 2500, 150, "Classic World", 6));
            toyDepartment.Add(4, new Toy("Кукла", 1000, 200, "FALK", 6));
            toyDepartment.Add(5, new Toy("Железная дорога", 4000, 30, "B.Toys", 6));
            store.Enqueue(toyDepartment.ToDictionary(k => k.Key, v => (Goods)v.Value));

            Dictionary<int, Product> productDepartment = new Dictionary<int, Product>();
            productDepartment.Add(1, new Product("Колбаса", 500, 100, "Состав1", 30));
            productDepartment.Add(2, new Product("Макароны", 70, 150, "Состав2", 180));
            productDepartment.Add(3, new Product("Хлеб", 50, 200, "Состав3", 5));
            productDepartment.Add(4, new Product("Печенье", 150, 200, "Состав4", 180));
            productDepartment.Add(5, new Product("Консервы", 150, 100, "Состав5", 30));
            store.Enqueue(productDepartment.ToDictionary(k => k.Key, v => (Goods)v.Value));

            Dictionary<int, MilkProduct> milkProductDepartment = new Dictionary<int, MilkProduct>();
            milkProductDepartment.Add(1, new MilkProduct("Молоко", 100, 200, "Состав1", 10, false, true));
            milkProductDepartment.Add(2, new MilkProduct("Сыр", 300, 150, "Состав2", 30, true, true));
            milkProductDepartment.Add(3, new MilkProduct("Йогурт", 70, 250, "Состав3", 30, false, true));
            milkProductDepartment.Add(4, new MilkProduct("Сметана", 80, 200, "Состав4", 10, false, true));
            milkProductDepartment.Add(5, new MilkProduct("НеМолоко", 250, 100, "Состав5", 10, true, true));
            milkProductDepartment.Add(6, new MilkProduct("НеМолоко", 150, 100, "Состав6", 10, true, false));
            store.Enqueue(milkProductDepartment.ToDictionary(k => k.Key, v => (Goods)v.Value));

            Dictionary<int, Goods> goodsDepartment = new Dictionary<int, Goods>();
            goodsDepartment.Add(1, new Goods("Швабра", 500, 100));
            goodsDepartment.Add(2, new Goods("Дезодорант", 200, 200));
            goodsDepartment.Add(3, new Goods("Зубная щетка", 150, 250));
            goodsDepartment.Add(4, new Goods("Кружка", 300, 50));
            goodsDepartment.Add(5, new Goods("Ложка", 150, 200));
            store.Enqueue(goodsDepartment);
            PrintQueue(store);
            #endregion

            ///////////////// LINQ-ЗАПРОСЫ
            # region LINQ-ЗАПРОСЫ
            PrintMenuLevel1("2. Запросы:");
            PrintMenuLevel2("2.1 LINQ:");

            PrintMenuLevel3("2.1.1 На выборку данных (Where)");
            PrintMenuLevel3("Наименование всех товаров отдела Игрушки");
            var timerLINQ = Stopwatch.StartNew();
            var toyProducts = from department in store
                      from product in department
                      where product.Value is Toy
                              select product.Value.Name;

            timerLINQ.Stop();
            foreach (var product in toyProducts)
            {
                PrintInformation(3, product);
            }
            Console.WriteLine();

            PrintMenuLevel3("2.1.2 Использование операций над множествами (Union, Except, Intersect)");

            PrintMenuLevel4("2.1.2.1 Объединение товаров из отделов Игрушки и Молочные продукты:");
            var unionProducts = (from department in store
                                from product in department
                                where product.Value is Toy
                                select product).Union(from department in store
                                                      from product in department
                                                      where product.Value is MilkProduct
                                                      select product);
            foreach (var product in unionProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel4("2.1.2.2 Вычитание товаров Игрушки, Продукты и Молочные продукты из отдела Товары:");
            var exceptProducts = (from department in store
                                from product in department
                                where product.Value is Goods 
                                  select product).Except(from department in store
                                                      from product in department
                                                      where product.Value is Toy || product.Value is Product
                                                         select product);
            foreach (var product in exceptProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel4("2.1.2.3 Пересечение товаров из отделов Toy и MilkProduct по цене:");
            var intersectPrices = (from department in store
                                   from product in department
                                   where product.Value is MilkProduct
                                   select product.Value.Price).Intersect(from department in store
                                                                         from product in department
                                                                         where product.Value is Toy
                                                                         select product.Value.Price);
            var intersectProducts = from department in store
                                    from product in department
                                    where intersectPrices.Contains(product.Value.Price)
                                    select product;

            foreach (var product in intersectProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel3("2.1.3 Агрегирование данных (Sum, Max, Min, Average)");

            PrintMenuLevel4("2.1.3.1 Суммарная стоимость 'не молока'");
            var sumPrices = (from department in store
                              from product in department
                              where product.Value.Name == "НеМолоко"
                               select product.Value.Price).Sum();

            PrintInformation(4, sumPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.1.3.2 Максимальная стоимость в отделе Игрушки");
            var maxPrices = (from department in store
                               from product in department
                               where product.Value is Toy
                               select product.Value.Price).Max();

            PrintInformation(4, maxPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.1.3.3 Минимальная стоимость в отделе Игрушки");
            var minPrices = (from department in store
                             from product in department
                             where product.Value is Toy
                             select product.Value.Price).Min();

            PrintInformation(4, minPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.1.3.4 Средняя стоимость в отделе Игрушки");
            var averagePrices = (from department in store
                             from product in department
                             where product.Value is Toy
                             select product.Value.Price).Average();

            PrintInformation(4, averagePrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel3("2.1.4 Группировка данных (Group by)");

            var groupByPrices = from department in store
                                from product in department
                                group product by product.Value.Price;

            foreach (var group in groupByPrices)
            {
                PrintInformation(3, $"Группа с ценой = {group.Key} руб. ");
                foreach (var product in group)
                    PrintInformation(4, product.Value.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();

            PrintMenuLevel3("2.1.5 Получение нового типа (Let)");
            PrintMenuLevel3("Суммарная стоимость товаров всех наименований:");
            var totalProductPrices = from department in store
                              from product in department
                              let totalPrice = product.Value.Price * product.Value.AmountGoods
                                     group totalPrice by product.Value.Name into grouped
                                     select new { Name = grouped.Key, TotalPrice = grouped.Sum()};

            PrintInformation(4, $"{"Наименование", -20}{"Цена, руб.", -15}");
            Console.WriteLine();
            foreach (var product in totalProductPrices)
            {
                PrintInformation(4, $"{product.Name, -20}{product.TotalPrice,-15}");
            }
            Console.WriteLine();
            PrintMenuLevel3("2.1.6 Соединение (Join)");

            Dictionary<int, Celler> sellers = new Dictionary<int, Celler>();
            sellers.Add(1, new Celler("B.Toys", "Канада"));
            sellers.Add(2, new Celler("Classic World", "Китай"));
            sellers.Add(3, new Celler("FALK", "Германия"));
            sellers.Add(4, new Celler("Geomag", "Китай"));

            var joinProductCellers = from department in store
                                     from product in department
                                     where product.Value is Toy
                                     let toyMaker = product.Value as Toy
                                     join seller in sellers on
                                     toyMaker.Maker equals seller.Value.Name
                                     select new { NameProduct = product.Value.Name, NameCeller = seller.Value.Name, Country = seller.Value.Country };

            PrintInformation(3, $"{"Наименование",-20}{"Изготовитель",-20}{"Страна",-20}");
            Console.WriteLine();
            foreach (var item in joinProductCellers)
            {
                PrintInformation(3, $"{item.NameProduct,-20}{item.NameCeller,-20}{item.Country,-20}");
            }
            Console.WriteLine();
            #endregion

            ///////////////// МЕТОДЫ РАСШИРЕНИЯ
            #region МЕТОДЫ РАСШИРЕНИЯ
            PrintMenuLevel2("2.2 МЕТОДЫ РАСШИРЕНИЯ:");
            PrintMenuLevel3("2.2.1 На выборку данных (Where)");
            PrintMenuLevel3("Наименование всех товаров отдела Игрушки");
            var timerMethodExtension = Stopwatch.StartNew();
            toyProducts = store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product.Value.Name);

            timerMethodExtension.Stop();
            foreach (var product in toyProducts)
            {
                PrintInformation(3, product);
            }
            Console.WriteLine();

            PrintMenuLevel3("2.2.2 Использование операций над множествами (Union, Except, Intersect)");
            PrintMenuLevel4("2.2.2.1 Объединение товаров из отделов Игрушки и Молочные продукты:");
            unionProducts = store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product)
                .Union(
                store
                .SelectMany(department => department)
                .Where(product => product.Value is MilkProduct))
                .Select(product => product);

            foreach (var product in unionProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel4("2.2.2.2 Вычитание товаров Игрушки, Продукты и Молочные продукты из отдела Товары:");
            exceptProducts = 
                store
                .SelectMany(department => department)
                .Where(product => product.Value is Goods)
                .Select(product => product)
                .Except(store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy || product.Value is Product)
                .Select(product => product));

            foreach (var product in exceptProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel4("2.1.2.3 Пересечение товаров из отделов Toy и MilkProduct по цене:");
            intersectPrices = store
                .SelectMany(department => department)
                .Where(product => product.Value is MilkProduct)
                .Select(product => product.Value.Price)
                .Intersect(
                store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product.Value.Price)
                );

            intersectProducts = store
                .SelectMany(department => department)
                .Where(product => intersectPrices.Contains(product.Value.Price))
                .Select(product => product);

            foreach (var product in intersectProducts)
            {
                PrintInformation(4, product.Value.ToString());
            }
            Console.WriteLine();

            PrintMenuLevel3("2.2.3 Агрегирование данных (Sum, Max, Min, Average)");

            PrintMenuLevel4("2.2.3.1 Суммарная стоимость 'не молока'");
            sumPrices = store
                .SelectMany(department => department)
                .Where(product => product.Value.Name == "НеМолоко")
                .Select(product => product.Value.Price).Sum();

            PrintInformation(4, sumPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.2.3.2 Максимальная стоимость в отделе Игрушки");
            maxPrices = store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product.Value.Price).Max();

            PrintInformation(4, maxPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.2.3.3 Минимальная стоимость в отделе Игрушки");
            minPrices = store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product.Value.Price).Min();

            PrintInformation(4, minPrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel4("2.2.3.4 Средняя стоимость в отделе Игрушки");
            averagePrices = store
                .SelectMany(department => department)
                .Where(product => product.Value is Toy)
                .Select(product => product.Value.Price).Average();

            PrintInformation(4, averagePrices.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel3("2.2.4 Группировка данных (Group by)");

            groupByPrices = store
                .SelectMany(department => department)
                .GroupBy(product => product.Value.Price);

            foreach (var group in groupByPrices)
            {
                PrintInformation(3, $"Группа с ценой = {group.Key} руб. ");
                foreach (var product in group)
                    PrintInformation(4, product.Value.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();

            PrintMenuLevel3("2.2.5 Получение нового типа (Let)");
            PrintMenuLevel3("Суммарная стоимость товаров всех наименований:");
            totalProductPrices = store
                .SelectMany(department => department)
                .Select(product => new
                {
                    product.Value.Name,
                    TotalPrice = product.Value.Price * product.Value.AmountGoods
                })
                .GroupBy(
                x => x.Name,
                x => x.TotalPrice,
                (name, prices) => new
                {
                    Name = name,
                    TotalPrice = prices.Sum()
                });


            PrintInformation(4, $"{"Наименование",-20}{"Цена, руб.",-15}");
            Console.WriteLine();
            foreach (var product in totalProductPrices)
            {
                PrintInformation(4, $"{product.Name,-20}{product.TotalPrice,-15}");
            }
            Console.WriteLine();

            PrintMenuLevel3("2.2.6 Соединение (Join)");
            joinProductCellers = store
               .SelectMany(department => department)
               .Where(product => product.Value is Toy)
               .Select(product => new
               {
                   Toy = (Toy)product.Value
               })
                .Join(sellers,
                toy => toy.Toy.Maker,
                sellers => sellers.Value.Name,
                (toy, sellers) => new
                {
                    NameProduct = toy.Toy.Name,
                    NameCeller = sellers.Value.Name,
                    Country = sellers.Value.Country
                }
                );


            PrintInformation(3, $"{"Наименование",-20}{"Изготовитель",-20}{"Страна",-20}");
            Console.WriteLine();
            foreach (var item in joinProductCellers)
            {
                PrintInformation(3, $"{item.NameProduct,-20}{item.NameCeller,-20}{item.Country,-20}");
            }
            Console.WriteLine();
            #endregion


            PrintMenuLevel1("3. ВРЕМЯ ВЫПОЛНЕНИЯ:");
            PrintInformation(1, $"Время выполнения LINQ-запроса = {timerLINQ.Elapsed.TotalMilliseconds} мс");
            PrintInformation(1, $"Время выполнения метода расширения = {timerMethodExtension.Elapsed.TotalMilliseconds} мс");


            PrintMenuLevel1("4. СОБСТВЕННЫЕ МЕТОДЫ РАСШИРЕНИЯ:");
            PrintMenuLevel2("4.1 Вывод наименований продуктов с суммой более 500 руб.:");
            var names = store
                .SelectMany(department => department)
                .GetProducts(p => p.Value.Price > 500)
                   .Select(p => p.Value.Name)
                   .ToList();
            foreach (var item in names)
            {
                PrintInformation(2, item);
            }
            Console.WriteLine();

            PrintMenuLevel2("4.2 Вывод cуммарной стоимости неМолока заданного наименования:");
            var sum = store
                .SelectMany(department => department)
                .SumPriceProduct(
                p => p.Value.Name == "НеМолоко",
                p => p.Value.Price,
                p => p.Value.AmountGoods
                );
            PrintInformation(2, sum.ToString() + " руб.");
            Console.WriteLine();

            PrintMenuLevel2("4.3 Вывод отсортированной коллекции:");
            var sort = store
                .SelectMany(department => department)
                .SortProductOrderBy();

            foreach (var item in sort)
            {
                PrintInformation(2, item.Value.ToString());
            }
            Console.ReadLine();
        }
        
        public class Celler
        {
            public string Name { get; set; }
            public string Country { get; set; }
            public Celler(string name, string country)
            {
                Name = name;
                Country = country;
            }
        }
        #region МЕНЮ
        static void PrintMenuLevel1(string info)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(info);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
        static void PrintMenuLevel2(string info)
        {
            Console.WriteLine("     " + info + "\n");
        }
        static void PrintMenuLevel3(string info)
        {
            Console.WriteLine("         " + info + "\n");
        }
        static void PrintMenuLevel4(string info)
        {
            Console.WriteLine("             " + info + "\n");
        }
        static void PrintInformation(int lvl, string info)
        {
            string space = "";
            switch (lvl)
            {
                case 2:
                    space = "     ";
                    break;
                case 3:
                    space = "         ";
                    break;
                case 4:
                    space = "             ";
                    break;
            }
            Console.WriteLine(space + info);
        }
        static void PrintQueue<TKey, TValue>(Queue<Dictionary<TKey, TValue>> queue)
        {
            int departmentNumber = 1;
            foreach (var department in queue)
            {
                PrintMenuLevel2($"Отдел {departmentNumber++} на очереди содержит {department.Count} товаров:");

                foreach (var product in department)
                {
                    PrintInformation(2, $"- ID: {product.Key}, Название: {product.Value}");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
