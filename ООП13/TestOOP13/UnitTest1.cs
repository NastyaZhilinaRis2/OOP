using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using ���10Library;
using ���13Library;
using System.Linq;
using System.Collections.Generic;

[TestClass]
public class ExtendedMyNewCollectionTests
{
    private MyNewCollection<string, Goods> mc;
    private Journal<string, Goods> journal;

    [TestInitialize]
    public void Setup()
    {
        mc = new MyNewCollection<string, Goods>("FurnitureCollection");
        journal = new Journal<string, Goods>();

        mc.CollectionCountChanged += journal.CollectionCountChanged;
        mc.CollectionReferenceChanged += journal.CollectionReferenceChanged;
    }
    // ���� 1: ���������� �������� � ��������� ��������������
    [TestMethod]
    public void Add_Element_TriggersCountChangedEvent()
    {
        // Arrange
        var goods = new Goods("�����", 15000, 2);

        // Act
        mc.Add(goods.Name, goods);

        // Assert
        Assert.AreEqual(1, mc.Count);
        Assert.AreEqual(1, journal.journal.Count);
        StringAssert.Contains(journal.journal.First(),
            $"�������� ���������: [FurnitureCollection], ��������: [add], ������: ���� [{goods.Name}], �������� [{goods}]");
    }

    // ���� 2: �������� �������� � ��������� ��������������
    [TestMethod]
    public void Remove_Element_TriggersCountChangedEvent()
    {
        // Arrange
        var goods = new Goods("����", 5000, 10);
        mc.Add(goods.Name, goods);

        // Act
        bool result = mc.Remove(goods.Name);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(0, mc.Count);
        Assert.AreEqual(2, journal.journal.Count);
        StringAssert.Contains(journal.journal.Last(),
            $"�������� ���������: [FurnitureCollection], ��������: [delete], ������: ���� [{goods.Name}], �������� [{goods}]");
    }

    // ���� 3: ��������� �������� ����� ����������
    [TestMethod]
    public void Update_Element_TriggersReferenceChangedEvent()
    {
        // Arrange
        var initialGoods = new Goods("����", 8000, 1);
        mc.Add(initialGoods.Name, initialGoods);
        var updatedGoods = new Goods("����", 10000, 2);

        // Act
        mc[initialGoods.Name] = updatedGoods;

        // Assert
        Assert.AreEqual(updatedGoods.Price, mc[initialGoods.Name].Price);
        Assert.AreEqual(2, journal.journal.Count);
        StringAssert.Contains(journal.journal.Last(),
            $"�������� ���������: [FurnitureCollection], ��������: [changed], ������: ���� [{initialGoods.Name}], �������� [{updatedGoods}]");
    }

    // ���� 4: ������� �������� ��������������� ��������
    [TestMethod]
    public void Remove_NonExistentElement_ReturnsFalse()
    {
        // Act
        bool result = mc.Remove("��������������");

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(0, journal.journal.Count);
    }

    // ���� 5: ��������� � ��������������� �����
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Get_NonExistentKey_ThrowsException()
    {
        // Act & Assert
        var value = mc["��������������"];
    }

    // ���� 6: ����������� ��������
    [TestMethod]
    public void Complex_Scenario_CorrectlyLogsAllEvents()
    {
        // Arrange
        var goods1 = new Goods("����", 20000, 1);
        var goods2 = new Goods("�������", 3000, 4);

        // Act
        mc.Add(goods1.Name, goods1);    // add
        mc[goods1.Name] = goods2;      // changed (������ ����� �� �������)
        mc.Remove(goods1.Name);         // delete

        // Assert
        Assert.AreEqual(3, journal.journal.Count);
        Assert.IsTrue(journal.journal[0].Contains("add"));
        Assert.IsTrue(journal.journal[1].Contains("changed"));
        Assert.IsTrue(journal.journal[2].Contains("delete"));
    }
    

    [TestMethod]
    public void Constructor_WithNameOnly_CreatesEmptyCollection()
    {
        // Arrange & Act
        var collection = new MyNewCollection<string, Goods>("TestCollection");

        // Assert
        Assert.AreEqual(0, collection.Count);
        Assert.AreEqual("TestCollection", collection.NameCollection);
    }

    [TestMethod]
    public void Constructor_WithCapacity_CreatesCollectionWithSpecifiedCapacity()
    {
        // Arrange & Act
        var collection = new MyNewCollection<string, Goods>("TestCollection", 100);

        // Assert
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void Constructor_WithExistingCollection_CopiesAllItems()
    {
        // Arrange
        var source = new MyNewCollection<string, Goods>("Source");
        var goods1 = new Goods("Item1", 100, 1);
        var goods2 = new Goods("Item2", 200, 2);
        source.Add("Item1", goods1);
        source.Add("Item2", goods2);

        // Act
        var copy = new MyNewCollection<string, Goods>("Copy", source);

        // Assert
        Assert.AreEqual(2, copy.Count);

        // ��������� ������� ������
        var keys = copy.Keys.ToList(); // ����������� � ������ ��� �������� ��������
        Assert.IsTrue(keys.Contains("Item1"));
        Assert.IsTrue(keys.Contains("Item2"));

        // ��������� ��������
        Assert.AreEqual(goods1, copy["Item1"]);
        Assert.AreEqual(goods2, copy["Item2"]);

        // ��������� ��� ����� ���������
        Assert.AreEqual("Copy", copy.NameCollection);
    }

    [TestMethod]
    public void Add_DuplicateKey_ThrowsArgumentException()
    {
        // Arrange
        var goods = new Goods("�����", 15000, 2);
        mc.Add(goods.Name, goods);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() =>
            mc.Add(goods.Name, new Goods("�����", 20000, 1)));
    }

    [TestMethod]
    public void CollectionHandlerEventArgs_ToString_ReturnsCorrectFormat()
    {
        // Arrange
        var goods = new Goods("������", 12000, 3);
        var args = new CollectionHandlerEventArgs<string, Goods>(
            "TestCollection", "test", goods.Name, goods);

        // Act
        var result = args.ToString();

        // Assert
        Assert.AreEqual($"TestCollection test {goods.Name} {goods}", result);
    }

    [TestMethod]
    public void JournalEntry_ToString_ReturnsCorrectFormat()
    {
        // Arrange
        var entry = new JournalEntry<string, Goods>(
            "TestCol", "operation", "key", new Goods("item", 100, 1));

        // Act
        var result = entry.ToString();

        // Assert
        Assert.AreEqual(
            "�������� ���������: [TestCol], ��������: [operation], ������: ���� [key], �������� [item, 100.00 ���., 1 ��.]",
            result);
    }

    [TestMethod]
    public void Journal_WithMultipleEvents_ContainsAllEntriesInOrder()
    {
        // Arrange
        var goods1 = new Goods("����", 8000, 1);
        var goods2 = new Goods("����", 3000, 4);

        // Act
        mc.Add(goods1.Name, goods1);
        mc.Add(goods2.Name, goods2);
        mc[goods1.Name] = new Goods("����", 9000, 2);
        mc.Remove(goods2.Name);

        // Assert
        Assert.AreEqual(4, journal.journal.Count);
        Assert.IsTrue(journal.journal[0].Contains("add") && journal.journal[0].Contains("����"));
        Assert.IsTrue(journal.journal[1].Contains("add") && journal.journal[1].Contains("����"));
        Assert.IsTrue(journal.journal[2].Contains("changed") && journal.journal[2].Contains("����"));
        Assert.IsTrue(journal.journal[3].Contains("delete") && journal.journal[3].Contains("����"));
    }

    [TestMethod]
    public void PrintJournal_WithMultipleEntries_OutputsAllEntries()
    {
        // Arrange
        var goods = new Goods("�����", 1500, 5);
        mc.Add(goods.Name, goods);
        mc.Remove(goods.Name);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        journal.PrintJournal();
        var output = stringWriter.ToString();

        // Assert
        Assert.IsTrue(output.Contains("�����"));
        Assert.IsTrue(output.Contains("add"));
        Assert.IsTrue(output.Contains("delete"));
        Assert.AreEqual(2, output.Split('\n').Count(line => line.Contains("�������� ���������")));
    }

    [TestMethod]
    public void CollectionEvents_WithMultipleSubscribers_AllAreNotified()
    {
        // Arrange
        var secondJournal = new Journal<string, Goods>();
        mc.CollectionCountChanged += secondJournal.CollectionCountChanged;

        var goods = new Goods("�����", 5000, 1);

        // Act
        mc.Add(goods.Name, goods);

        // Assert
        Assert.AreEqual(1, journal.journal.Count);
        Assert.AreEqual(1, secondJournal.journal.Count);
    }

    [TestMethod]
    public void Remove_LastItem_CollectionBecomesEmpty()
    {
        // Arrange
        var goods = new Goods("����", 3000, 1);
        mc.Add(goods.Name, goods);

        // Act
        var result = mc.Remove(goods.Name);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(0, mc.Count);
    }

    [TestMethod]
    public void Indexer_SetNewKey_AddsItemWithoutCountChangedEvent()
    {
        // Arrange
        var goods = new Goods("�������", 7000, 1);

        // Act
        mc["���������"] = goods;

        // Assert
        Assert.AreEqual(1, mc.Count);
        Assert.AreEqual(2, journal.journal.Count); // ������ reference changed
        Assert.IsTrue(journal.journal[0].Contains("changed"));
    }

    [TestMethod]
    public void CollectionHandler_WithNullValues_HandlesCorrectly()
    {
        // Arrange
        var args = new CollectionHandlerEventArgs<string, Goods>(
            null, null, null, null);

        // Act
        var result = args.ToString();

        // Assert
        Assert.AreEqual("   ", result); // ��� null ��������
    }

    [TestMethod]
    public void Journal_WithNullEventArguments_HandlesGracefully()
    {
        // Arrange
        var nullArgs = new CollectionHandlerEventArgs<string, Goods>(
            null, null, null, null);

        // Act
        journal.CollectionCountChanged(null, nullArgs);
        journal.CollectionReferenceChanged(null, nullArgs);

        // Assert
        Assert.AreEqual(2, journal.journal.Count);
        Assert.IsTrue(journal.journal[0].Contains("�������� ���������: [], ��������: [], ������: ���� [], �������� []"));
    }

}