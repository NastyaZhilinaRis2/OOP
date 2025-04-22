using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ООП10Library;
using ООП11;

namespace TestOOP11
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TimeWorkTests
        {
            private LinkedList<int> _linkedList;
            private Dictionary<int, string> _dictionary;

            [TestInitialize]
            public void Setup()
            {
                // Инициализация LinkedList
                _linkedList = new LinkedList<int>();
                for (int i = 0; i < 1000; i++)
                {
                    _linkedList.AddLast(i);
                }

                // Инициализация Dictionary
                _dictionary = new Dictionary<int, string>();
                for (int i = 0; i < 1000; i++)
                {
                    _dictionary[i] = $"Value {i}";
                }
            }

            [TestMethod]
            public void Test_LinkedList_Contains_ExistingElement()
            {
                var result = TimeWork.TimeOfWorkList(_linkedList, 500);
                Assert.IsTrue(result.Contains("Найден: True"));
            }

            [TestMethod]
            public void Test_LinkedList_Contains_NonExistingElement()
            {
                var result = TimeWork.TimeOfWorkList(_linkedList, 1500);
                Assert.IsTrue(result.Contains("Найден: False"));
            }

            [TestMethod]
            public void Test_Dictionary_ContainsKey_ExistingKey()
            {
                var result = TimeWork.TimeOfWorkDictionary(_dictionary, 500);
                Assert.IsTrue(result.Contains("Найден: True"));
            }

            [TestMethod]
            public void Test_Dictionary_ContainsKey_NonExistingKey()
            {
                var result = TimeWork.TimeOfWorkDictionary(_dictionary, 1500);
                Assert.IsTrue(result.Contains("Найден: False"));
            }

            [TestMethod]
            public void Test_Dictionary_ContainsValue_ExistingValue()
            {
                var result = TimeWork.TimeOfWorkDictionary(_dictionary, "Value 500");
                Assert.IsTrue(result.Contains("Найден: True"));
            }

            [TestMethod]
            public void Test_Dictionary_ContainsValue_NonExistingValue()
            {
                var result = TimeWork.TimeOfWorkDictionary(_dictionary, "Value 1500");
                Assert.IsTrue(result.Contains("Найден: False"));
            }
        }
    }
    [TestClass]
    public class TestCollectionsTests
    {
        private TestCollections _testCollections;

        [TestInitialize]
        public void Setup()
        {
            _testCollections = new TestCollections();
        }

        [TestMethod]
        public void Test_Add_Product()
        {
            // Arrange
            Product product = new Product();
            product.RandomInit();

            // Act
            bool result = _testCollections.Add(product);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1001, _testCollections.Count); // 1000 из конструктора + 1 добавленный продукт
            Assert.IsTrue(_testCollections.listProduct.Contains(product));
            Assert.IsTrue(_testCollections.dictionaryKeyGoods.ContainsKey(product.BaseGoods));
            Assert.IsTrue(_testCollections.dictionaryKeyStr.ContainsKey(product.BaseGoods.ToString()));
        }

        [TestMethod]
        public void Test_Delete_Product()
        {
            // Arrange
            Product product = new Product();
            product.RandomInit();
            _testCollections.Add(product); // Добавляем продукт перед удалением
            // Act
            bool result = _testCollections.Delete(product);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1000, _testCollections.Count); // 1001 - 1 удаленный продукт
            Assert.IsFalse(_testCollections.listProduct.Contains(product));
            Assert.IsFalse(_testCollections.dictionaryKeyStr.ContainsKey(product.BaseGoods.ToString()));
            Assert.IsFalse(_testCollections.dictionaryKeyGoods.ContainsKey(product.BaseGoods));
        }

        [TestMethod]
        public void Test_Delete_NonExistent_Product()
        {
            // Arrange
            Product product = new Product();
            product.RandomInit();

            // Act
            bool result = _testCollections.Delete(product);

            // Assert
            Assert.IsFalse(result); // Удаление несуществующего продукта должно вернуть false
            Assert.AreEqual(1000, _testCollections.Count); // Количество должно остаться прежним
        }



        [TestMethod]
        public void Test_Empty_Collection_Delete()
        {
            // Act
            Product product = new Product();
            product.RandomInit();
            bool result = _testCollections.Delete(product); // Пытаемся удалить из пустой коллекции

            // Assert
            Assert.IsFalse(result); 
            Assert.AreEqual(1000, _testCollections.Count); // Количество должно остаться прежним
        }
    }
    [TestClass]
    public class GeneralizedCollectionTests
    {
        private GeneralizedCollection _collection;

        [TestInitialize]
        public void Setup()
        {
            _collection = new GeneralizedCollection();
        }

        [TestMethod]
        public void Test_AddRandom()
        {
            _collection.AddRandom();
            Assert.AreEqual(1, _collection.CountListCollections);
        }

        [TestMethod]
        public void Test_Add_ValidGoods()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            _collection.Add(toy);
            Assert.AreEqual(1, _collection.CountListCollections);
        }

        [TestMethod]
        public void Test_Delete_ValidIndex()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            _collection.Add(toy);
            _collection.Delete(0);
            Assert.AreEqual(0, _collection.CountListCollections);
        }

        [TestMethod]
        public void Test_Delete_InvalidIndex()
        {
            _collection.Delete(0);
            Assert.AreEqual(0, _collection.CountListCollections);
        }

        [TestMethod]
        public void Test_SearchInList_ExistentItem()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            _collection.Add(toy);
            Assert.IsTrue(_collection.SearchInList(toy));
        }

        [TestMethod]
        public void Test_SearchInList_NonExistentItem()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            Assert.IsFalse(_collection.SearchInList(toy)); 
        }

        [TestMethod]
        public void Test_AmountType()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            Goods product = new Product { Name = "Product1", Price = 20.0m };
            _collection.Add(toy);
            _collection.Add(product);
            Assert.AreEqual(1, _collection.AmountType<Toy>());
        }

        [TestMethod]
        public void Test_TotalPrice()
        {
            Goods toy1 = new Toy { Name = "Toy1", Price = 10.0m };
            Goods toy2 = new Toy { Name = "Toy2", Price = 15.0m };
            _collection.Add(toy1);
            _collection.Add(toy2);
            Assert.AreEqual(25.0m, _collection.TotalPrice<Toy>());
        }

        [TestMethod]
        public void Test_Clone()
        {
            Goods toy = new Toy { Name = "Toy1", Price = 10.0m };
            _collection.Add(toy);
            var clone = (GeneralizedCollection)_collection.Clone();
            Assert.AreEqual(1, clone.CountListCollections);
            Assert.AreEqual(toy.Name, ((Toy)clone.ListCollections[0]).Name);
        }
    }
    [TestClass]
    public class CoollectionsTests
    {
        private Coollections collections;

        [TestInitialize]
        public void Setup()
        {
            collections = new Coollections();
        }

        [TestMethod]
        public void Test_AddAndCount()
        {
            var toy = new Toy(); 
            collections.Add(toy);
            Assert.AreEqual(1, collections.CountStack);
        }

        [TestMethod]
        public void Test_DeleteByIndex()
        {
            var toy1 = new Toy();
            var toy2 = new Toy();
            collections.Add(toy1);
            collections.Add(toy2);

            collections.Delete(0);
            Assert.AreEqual(1, collections.CountStack);
            collections.Delete(0);
            Assert.AreEqual(0, collections.CountStack);
        }

        [TestMethod]
        public void Test_DeleteOutOfRange()
        {
            var toy = new Toy();
            collections.Add(toy);
            collections.Delete(1); 
            Assert.AreEqual(1, collections.CountStack);
        }

        [TestMethod]
        public void Test_Print()
        {
            var toy = new Toy();
            collections.Add(toy);

            Assert.AreEqual(1, collections.CountStack);
        }

        [TestMethod]
        public void Test_RandomInit()
        {
            var goods = collections.RandomInit();
            Assert.IsInstanceOfType(goods, typeof(Goods));
        }

        [TestMethod]
        public void Test_AmountTypeGoods()
        {
            var toy1 = new Toy();
            var toy2 = new Toy();
            var product = new Product();

            collections.Add(toy1);
            collections.Add(toy2);
            collections.Add(product);

            Assert.AreEqual(2, collections.AmountTypeGoods<Toy>());
        }

        [TestMethod]
        public void Test_TotalPriceGoods()
        {
            var toy1 = new Toy { Price = 10.0m };
            var toy2 = new Toy { Price = 15.0m };
            collections.Add(toy1);
            collections.Add(toy2);

            Assert.AreEqual(25.0m, collections.TotalPriceGoods<Toy>());
        }

        [TestMethod]
        public void Test_Clone()
        {
            var toy = new Toy();
            collections.Add(toy);

            var clone = collections.Clone() as Coollections;
            Assert.IsNotNull(clone);
            Assert.AreEqual(collections.CountStack, clone.CountStack);
        }
    }
}
