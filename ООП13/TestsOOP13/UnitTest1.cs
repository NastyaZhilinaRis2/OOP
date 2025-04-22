using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ООП10Library;
using ООП13;

[TestClass]
public class MyNewCollectionTests
{
    private MyNewCollection<string, Goods> mc;
    private Journal<string, Goods> journal;

    [TestInitialize]
    public void Setup()
    {
        mc = new MyNewCollection<string, Goods>("FurnitureCollection");
        journal = new Journal<string, Goods>();

        // Подписываем журнал на события коллекции
        mc.CollectionCountChanged += journal.CollectionCountChanged;
        mc.CollectionReferenceChanged += journal.CollectionReferenceChanged;
    }

    // Тест 1: Добавление элемента с проверкой журналирования
    [TestMethod]
    public void Add_Element_TriggersCountChangedEvent()
    {
        // Arrange
        var goods = new Goods("Диван", 15000, 2);

        // Act
        mc.Add(goods.Name, goods);

        // Assert
        Assert.AreEqual(1, mc.Count);
        Assert.AreEqual(1, journal.journal.Count);
        StringAssert.Contains(journal.journal.First(),
            $"Название коллекции: [FurnitureCollection], Операция: [add], Объект: ключ [{goods.Name}], значение [{goods}]");
    }

    // Тест 2: Удаление элемента с проверкой журналирования
    [TestMethod]
    public void Remove_Element_TriggersCountChangedEvent()
    {
        // Arrange
        var goods = new Goods("Стул", 5000, 10);
        mc.Add(goods.Name, goods);

        // Act
        bool result = mc.Remove(goods.Name);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(0, mc.Count);
        Assert.AreEqual(2, journal.journal.Count);
        StringAssert.Contains(journal.journal.Last(),
            $"Название коллекции: [FurnitureCollection], Операция: [delete], Объект: ключ [{goods.Name}], значение [{goods}]");
    }

    // Тест 3: Изменение элемента через индексатор
    [TestMethod]
    public void Update_Element_TriggersReferenceChangedEvent()
    {
        // Arrange
        var initialGoods = new Goods("Стол", 8000, 1);
        mc.Add(initialGoods.Name, initialGoods);
        var updatedGoods = new Goods("Стол", 10000, 2);

        // Act
        mc[initialGoods.Name] = updatedGoods;

        // Assert
        Assert.AreEqual(updatedGoods.Price, mc[initialGoods.Name].Price);
        Assert.AreEqual(2, journal.journal.Count);
        StringAssert.Contains(journal.journal.Last(),
            $"Название коллекции: [FurnitureCollection], Операция: [changed], Объект: ключ [{initialGoods.Name}], значение [{updatedGoods}]");
    }

    // Тест 4: Попытка удаления несуществующего элемента
    [TestMethod]
    public void Remove_NonExistentElement_ReturnsFalse()
    {
        // Act
        bool result = mc.Remove("Несуществующий");

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(0, journal.journal.Count);
    }

    // Тест 5: Обращение к несуществующему ключу
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Get_NonExistentKey_ThrowsException()
    {
        // Act & Assert
        var value = mc["Несуществующий"];
    }

    // Тест 6: Комплексный сценарий
    [TestMethod]
    public void Complex_Scenario_CorrectlyLogsAllEvents()
    {
        // Arrange
        var goods1 = new Goods("Шкаф", 20000, 1);
        var goods2 = new Goods("Зеркало", 3000, 4);

        // Act
        mc.Add(goods1.Name, goods1);    // add
        mc[goods1.Name] = goods2;      // changed (замена шкафа на зеркало)
        mc.Remove(goods1.Name);         // delete

        // Assert
        Assert.AreEqual(3, journal.journal.Count);
        Assert.IsTrue(journal.journal[0].Contains("add"));
        Assert.IsTrue(journal.journal[1].Contains("changed"));
        Assert.IsTrue(journal.journal[2].Contains("delete"));
    }
}