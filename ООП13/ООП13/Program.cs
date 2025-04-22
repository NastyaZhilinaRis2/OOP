using System;
using ООП10Library;
using ООП12Library;
using ООП13Library;

class Program
{
    static void PrintMenuInfo(string info)
    {

        Console.WriteLine("----------------------------------------------------------------------------------------------");
        Console.WriteLine(info);
        Console.WriteLine("----------------------------------------------------------------------------------------------");
    }
    static void Main(string[] args)
    {
        MyNewCollection<string, Goods> mc1 = new MyNewCollection<string, Goods>("First");

        MyNewCollection<string, Goods> mc2 = new MyNewCollection<string, Goods>("Second");


        Journal<string, Goods> joun1 = new Journal<string, Goods>();
        mc1.CollectionCountChanged += new CollectionHandler<string, Goods>(joun1.CollectionCountChanged);
        mc1.CollectionReferenceChanged += new CollectionHandler<string, Goods>(joun1.CollectionReferenceChanged);

        //другой объект Journal подписать на события CollectionReferenceChanged из обеих коллекций
        Journal<string, Goods> joun2 = new Journal<string, Goods>();
        mc1.CollectionReferenceChanged += new CollectionHandler<string, Goods>(joun2.CollectionReferenceChanged);
        mc2.CollectionReferenceChanged += new CollectionHandler<string, Goods>(joun2.CollectionReferenceChanged);

        PrintMenuInfo($"ДОБАВЛЕНИЕ элементов в {mc1.NameCollection} коллекцию");

        mc1.Add("Диван", new Goods("Диван", 15000, 2));
        mc1.Add("Стул", new Goods("Стул", 3000, 5));
        mc1.Add("Стол", new Goods("Стол", 8000, 1));

        mc1.Print();

        PrintMenuInfo($"УДАЛЕНИЕ элементов из {mc1.NameCollection} коллекции");

        mc1.Remove("Диван");
        mc1.Remove("Стул");

        mc1.Print();

        PrintMenuInfo($"ИЗМЕНЕНИЕ значения элемента из {mc1.NameCollection} коллекции");

        Goods goodsNew = new Goods("Новое значение", 0, 0);

        mc1["Стол"] = goodsNew;

        mc1.Print();

        Console.WriteLine();
        Console.WriteLine();

        PrintMenuInfo($"ДОБАВЛЕНИЕ элементов во {mc2.NameCollection} коллекцию");

        mc2.Add("Кровать", new Goods("Кровать", 10000, 2));
        mc2.Add("Кресло", new Goods("Кресло", 5000, 5));
        mc2.Add("Ковер", new Goods("Ковер", 3000, 1));

        mc2.Print();

        PrintMenuInfo($"УДАЛЕНИЕ элементы из {mc2.NameCollection} коллекции");

        mc2.Remove("Кровать");
        mc2.Remove("Кресло");

        mc2.Print();

        PrintMenuInfo($"ИЗМЕНЕНИЕ значения элемента из {mc2.NameCollection} коллекции");

        mc2["Ковер"] = goodsNew;

        mc2.Print();

        Console.WriteLine();
        Console.WriteLine();


        Console.WriteLine($"{mc1.NameCollection} журнал");
        joun1.PrintJournal();
        Console.WriteLine();
        Console.WriteLine($"{mc2.NameCollection} журнал");
        joun2.PrintJournal();
        Console.ReadLine();
    }
}