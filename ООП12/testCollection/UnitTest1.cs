using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ���12Library;
using System.IO;

namespace ���12Library.testOOP12
{
    [TestClass]
    public class HashTableCollectionTests
    {
        private HashTableCollection<string, int> testCollections;

        [TestInitialize]
        public void Setup()
        {
            testCollections = new HashTableCollection<string, int>();
        }

        // ���������� ��������
        [TestMethod]
        public void Test_Add_Product()
        {
            // Arrange
            string key = "apple";
            int value = 1;

            // Act
            testCollections.Add(key, value);

            // Assert
            Assert.AreEqual(1, testCollections.Count); // ��������� 1 ����������� �������
            Assert.IsTrue(testCollections.ContainsKey(key)); // �������� �� ������������� �����
            Assert.AreEqual(value, testCollections[key]); // �������� �������� �� �����
        }

        // ���������� ���������
        [TestMethod]
        public void Test_Add_Duplicate_Product()
        {
            // Arrange
            string key = "banana";
            int value = 2;
            testCollections.Add(key, value);

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                testCollections.Add(key, value); // ������� �������� ��������
            });
        }

        // �������� ��������
        [TestMethod]
        public void Test_Remove_Product()
        {
            // Arrange
            string key = "orange";
            int value = 3;
            testCollections.Add(key, value);

            // Act
            bool result = testCollections.Remove(key);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, testCollections.Count); // ��������� 0 ��������� ����� ��������
            Assert.IsFalse(testCollections.ContainsKey(key)); // ��������, ��� ���� ��� ������
        }

        // ����������� � ������
        [TestMethod]
        public void Test_CopyTo_Array()
        {
            // Arrange
            testCollections.Add("grape", 4);
            testCollections.Add("kiwi", 5);
            var array = new KeyValuePair<string, int>[2];

            // Act
            testCollections.CopyTo(array, 0);

            // Assert
            Assert.AreEqual(2, array.Length);
            Assert.IsTrue(array[0].Key == "grape" && array[0].Value == 4);
            Assert.IsTrue(array[1].Key == "kiwi" && array[1].Value == 5);
        }

        // �������� ������� �����
        [TestMethod]
        public void Test_ContainsKey()
        {
            // Arrange
            string key = "melon";
            int value = 6;
            testCollections.Add(key, value);

            // Act & Assert
            Assert.IsTrue(testCollections.ContainsKey(key));
            Assert.IsFalse(testCollections.ContainsKey("nonexistent")); // �������� �� �������������� ����
        }

        // �������� ���������� ���������
        [TestMethod]
        public void Test_Add()
        {
            // Arrange
            var kvp1 = new KeyValuePair<string, int>("apple", 1);
            var kvp2 = new KeyValuePair<string, int>("banana", 2);

            // Act
            testCollections.Add(kvp1);
            testCollections.Add(kvp2);

            // Assert
            Assert.IsTrue(testCollections.Contains(kvp1)); // �������, ��� ��������� �������� kvp1
            Assert.IsTrue(testCollections.Contains(kvp2)); // �������, ��� ��������� �������� kvp2
            Assert.AreEqual(2, testCollections.Count); // �������, ��� ���������� ��������� ����� 2
        }

        // �������� �������� ���������
        [TestMethod]
        public void Test_Remove()
        {
            // Arrange
            var kvp = new KeyValuePair<string, int>("apple", 1);
            testCollections.Add(kvp);

            // Act
            bool removed = testCollections.Remove(kvp);

            // Assert
            Assert.IsTrue(removed); // �������, ��� ������� ��� ������� ������
            Assert.IsFalse(testCollections.Contains(kvp)); // �������, ��� ��������� �� �������� kvp
            Assert.AreEqual(0, testCollections.Count); // �������, ��� ���������� ��������� ����� 0
        }

        // �������� ��������� �������� �� ������������� �����
        [TestMethod]
        public void Test_TryGetValue_ExistentKey()
        {
            // Arrange
            var kvp = new KeyValuePair<string, int>("apple", 1);
            testCollections.Add(kvp);

            // Act
            bool result = testCollections.TryGetValue("apple", out int value);

            // Assert
            Assert.IsTrue(result); // �������, ��� ��������� ����� true
            Assert.AreEqual(1, value); // �������, ��� �������� ����� 1
        }

        // �������� ������� ��������� �������� �� ��������������� �����
        [TestMethod]
        public void Test_TryGetValue_NonExistentKey()
        {
            // Arrange
            string key = "nonexistent";

            // Act
            bool result = testCollections.TryGetValue(key, out int value);

            // Assert
            Assert.IsFalse(result); // �������, ��� ��������� ����� false
            Assert.AreEqual(0, value); // �������� ������ ���� �� ��������� (0 ��� int)
        }

        // �������� ��������� ���� ������
        [TestMethod]
        public void Test_Keys()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var keys = testCollections.Keys;

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "apple", "banana" }, new List<string>(keys)); // �������, ��� ����� ���������
        }

        // �������� ��������� ���� ��������
        [TestMethod]
        public void Test_Values()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var values = testCollections.Values;

            // Assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, new List<int>(values)); // �������, ��� �������� ���������
        }

        // �������� ������� ���������
        [TestMethod]
        public void Test_Clear()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            testCollections.Clear();

            // Assert
            Assert.AreEqual(0, testCollections.Count); // �������, ��� ���������� ��������� ����� 0
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("banana", 2))); // �������, ��� ��������� �� �������� "banana"
        }

        // �������� ����������
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CopyTo_NullArray()
        {
            // Act
            testCollections.CopyTo(null, 0); // ������ ��������� ArgumentNullException
        }

        // �������� �� ������������ ������ ��� ����������� � ������
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CopyTo_InvalidArrayIndex()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            testCollections.CopyTo(new KeyValuePair<string, int>[1], -1); // ������ ��������� ArgumentOutOfRangeException
        }

        // �������� �� ������������� ������������ � �������
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CopyTo_InsufficientSpace()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            testCollections.CopyTo(new KeyValuePair<string, int>[1], 0); // ������ ��������� ArgumentException
        }

        // �������� �� ���������� ���������� ���������� ��������� � ���������
        [TestMethod]
        public void Test_AddRange()
        {
            // Arrange
            var itemsToAdd = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("apple", 1),
            new KeyValuePair<string, int>("banana", 2)
        };

            // Act
            testCollections.AddRange(itemsToAdd);

            // Assert
            Assert.AreEqual(2, testCollections.Count); // �������, ��� ���������� ��������� ����� 2
            Assert.IsTrue(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsTrue(testCollections.Contains(new KeyValuePair<string, int>("banana", 2)));
        }

        // �������� �� ���������� �������� ���������� ��������� �� ���������
        [TestMethod]
        public void Test_RemoveRange()
        {
            // Arrange
            var itemsToRemove = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("apple", 1),
            new KeyValuePair<string, int>("banana", 2)
        };
            testCollections.AddRange(itemsToRemove);

            // Act
            testCollections.RemoveRange(itemsToRemove);

            // Assert
            Assert.AreEqual(0, testCollections.Count); // �������, ��� ���������� ��������� ����� 0
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("banana", 2)));
        }

        // �������� TryGetKey ��� ������������� ��������
        [TestMethod]
        public void Test_TryGetKey_ExistentValue()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            bool result = testCollections.TryGetKey(1, out string key);

            // Assert
            Assert.IsTrue(result); // �������, ��� ��������� ����� true
            Assert.AreEqual("apple", key); // �������, ��� ���� ����� "apple"
        }

        // �������� TryGetKey ��� ��������������� ��������
        [TestMethod]
        public void Test_TryGetKey_NonExistentValue()
        {
            // Act
            bool result = testCollections.TryGetKey(99, out string key);

            // Assert
            Assert.IsFalse(result); // �������, ��� ��������� ����� false
            Assert.IsNull(key); // �������, ��� ���� ����� ����� null
        }

        // �������� ������ Dispose, ��� �� ����������� ������� ���������
        [TestMethod]
        public void Test_Dispose()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            testCollections.Dispose();

            // Assert
            Assert.ThrowsException<ObjectDisposedException>(() => testCollections.Add(new KeyValuePair<string, int>("banana", 2))); // �������, ��� ����� Dispose ������ ��������� ��������
        }

        // �������� ������ DeepClone, ��� �� ������� ������ ����� ���������
        [TestMethod]
        public void Test_DeepClone()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var clonedCollection = testCollections.DeepClone();

            // Assert
            Assert.AreEqual(2, clonedCollection.Count); // �������, ��� ������������� ��������� �������� 2 ��������
            Assert.IsTrue(clonedCollection.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsTrue(clonedCollection.Contains(new KeyValuePair<string, int>("banana", 2)));

            // ��������, ��� ��� ������ �������
            Assert.AreNotSame(testCollections, clonedCollection);
        }

        // �������� ������ ShallowCopy, ��� �� ������� ������������� ����� ���������
        [TestMethod]
        public void Test_ShallowCopy()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            var shallowCopy = testCollections.ShallowCopy();

            // Assert
            Assert.AreEqual(1, shallowCopy.Count); // �������, ��� ���������� ��������� ����� 1
            Assert.IsTrue(shallowCopy.Contains(new KeyValuePair<string, int>("apple", 1)));

            // ��������, ��� ��� ������ �������
            Assert.AreNotSame(testCollections, shallowCopy);
        }

        // �������� ������ Print, ��� �� ��������� ������� ���������� ���������
        [TestMethod]
        public void Test_Print()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // �������������� ����� � StringWriter

                // Act
                testCollections.Print(); // �������� ���������

                // Assert
                var result = sw.ToString().Trim(); // �������� ��������� ������
                Assert.IsTrue(result.Contains("apple")); // ���������, ��� ����� �������� "apple"
                Assert.IsTrue(result.Contains("banana")); // ���������, ��� ����� �������� "banana"
            }
        }
    }
}



