using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ���10Library;
using ���13;

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

        // ����������� ������ �� ������� ���������
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
}