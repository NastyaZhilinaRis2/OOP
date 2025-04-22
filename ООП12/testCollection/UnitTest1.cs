using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ООП12Library;
using System.IO;

namespace ООП12Library.testOOP12
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

        // добавление элемента
        [TestMethod]
        public void Test_Add_Product()
        {
            // Arrange
            string key = "apple";
            int value = 1;

            // Act
            testCollections.Add(key, value);

            // Assert
            Assert.AreEqual(1, testCollections.Count); // ожидается 1 добавленный элемент
            Assert.IsTrue(testCollections.ContainsKey(key)); // проверка на существование ключа
            Assert.AreEqual(value, testCollections[key]); // проверка значения по ключу
        }

        // добавление дубликата
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
                testCollections.Add(key, value); // попытка добавить дубликат
            });
        }

        // удаление элемента
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
            Assert.AreEqual(0, testCollections.Count); // ожидается 0 элементов после удаления
            Assert.IsFalse(testCollections.ContainsKey(key)); // проверка, что ключ был удален
        }

        // копирование в массив
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

        // проверка наличия ключа
        [TestMethod]
        public void Test_ContainsKey()
        {
            // Arrange
            string key = "melon";
            int value = 6;
            testCollections.Add(key, value);

            // Act & Assert
            Assert.IsTrue(testCollections.ContainsKey(key));
            Assert.IsFalse(testCollections.ContainsKey("nonexistent")); // проверка на несуществующий ключ
        }

        // проверка добавления элементов
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
            Assert.IsTrue(testCollections.Contains(kvp1)); // ожидаем, что коллекция содержит kvp1
            Assert.IsTrue(testCollections.Contains(kvp2)); // ожидаем, что коллекция содержит kvp2
            Assert.AreEqual(2, testCollections.Count); // ожидаем, что количество элементов равно 2
        }

        // проверка удаления элементов
        [TestMethod]
        public void Test_Remove()
        {
            // Arrange
            var kvp = new KeyValuePair<string, int>("apple", 1);
            testCollections.Add(kvp);

            // Act
            bool removed = testCollections.Remove(kvp);

            // Assert
            Assert.IsTrue(removed); // ожидаем, что элемент был успешно удален
            Assert.IsFalse(testCollections.Contains(kvp)); // ожидаем, что коллекция не содержит kvp
            Assert.AreEqual(0, testCollections.Count); // ожидаем, что количество элементов равно 0
        }

        // проверка получения значения по существующему ключу
        [TestMethod]
        public void Test_TryGetValue_ExistentKey()
        {
            // Arrange
            var kvp = new KeyValuePair<string, int>("apple", 1);
            testCollections.Add(kvp);

            // Act
            bool result = testCollections.TryGetValue("apple", out int value);

            // Assert
            Assert.IsTrue(result); // ожидаем, что результат будет true
            Assert.AreEqual(1, value); // ожидаем, что значение равно 1
        }

        // проверка попытки получения значения по несуществующему ключу
        [TestMethod]
        public void Test_TryGetValue_NonExistentKey()
        {
            // Arrange
            string key = "nonexistent";

            // Act
            bool result = testCollections.TryGetValue(key, out int value);

            // Assert
            Assert.IsFalse(result); // ожидаем, что результат будет false
            Assert.AreEqual(0, value); // значение должно быть по умолчанию (0 для int)
        }

        // проверка получения всех ключей
        [TestMethod]
        public void Test_Keys()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var keys = testCollections.Keys;

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "apple", "banana" }, new List<string>(keys)); // ожидаем, что ключи совпадают
        }

        // проверка получения всех значений
        [TestMethod]
        public void Test_Values()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var values = testCollections.Values;

            // Assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, new List<int>(values)); // ожидаем, что значения совпадают
        }

        // проверка очистки коллекции
        [TestMethod]
        public void Test_Clear()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            testCollections.Clear();

            // Assert
            Assert.AreEqual(0, testCollections.Count); // ожидаем, что количество элементов равно 0
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("banana", 2))); // ожидаем, что коллекция не содержит "banana"
        }

        // проверка исключений
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CopyTo_NullArray()
        {
            // Act
            testCollections.CopyTo(null, 0); // должно выбросить ArgumentNullException
        }

        // проверка на некорректный индекс при копировании в массив
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CopyTo_InvalidArrayIndex()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            testCollections.CopyTo(new KeyValuePair<string, int>[1], -1); // должно выбросить ArgumentOutOfRangeException
        }

        // проверка на недостаточное пространство в массиве
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CopyTo_InsufficientSpace()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            testCollections.CopyTo(new KeyValuePair<string, int>[1], 0); // должно выбросить ArgumentException
        }

        // проверка на корректное добавление нескольких элементов в коллекцию
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
            Assert.AreEqual(2, testCollections.Count); // ожидаем, что количество элементов равно 2
            Assert.IsTrue(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsTrue(testCollections.Contains(new KeyValuePair<string, int>("banana", 2)));
        }

        // проверка на корректное удаление нескольких элементов из коллекции
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
            Assert.AreEqual(0, testCollections.Count); // ожидаем, что количество элементов равно 0
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsFalse(testCollections.Contains(new KeyValuePair<string, int>("banana", 2)));
        }

        // проверка TryGetKey для существующего значения
        [TestMethod]
        public void Test_TryGetKey_ExistentValue()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            bool result = testCollections.TryGetKey(1, out string key);

            // Assert
            Assert.IsTrue(result); // ожидаем, что результат будет true
            Assert.AreEqual("apple", key); // ожидаем, что ключ равен "apple"
        }

        // проверка TryGetKey для несуществующего значения
        [TestMethod]
        public void Test_TryGetKey_NonExistentValue()
        {
            // Act
            bool result = testCollections.TryGetKey(99, out string key);

            // Assert
            Assert.IsFalse(result); // ожидаем, что результат будет false
            Assert.IsNull(key); // ожидаем, что ключ будет равен null
        }

        // проверка метода Dispose, что он освобождает ресурсы коллекции
        [TestMethod]
        public void Test_Dispose()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            testCollections.Dispose();

            // Assert
            Assert.ThrowsException<ObjectDisposedException>(() => testCollections.Add(new KeyValuePair<string, int>("banana", 2))); // ожидаем, что после Dispose нельзя добавлять элементы
        }

        // проверка метода DeepClone, что он создает полную копию коллекции
        [TestMethod]
        public void Test_DeepClone()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            // Act
            var clonedCollection = testCollections.DeepClone();

            // Assert
            Assert.AreEqual(2, clonedCollection.Count); // ожидаем, что клонированная коллекция содержит 2 элемента
            Assert.IsTrue(clonedCollection.Contains(new KeyValuePair<string, int>("apple", 1)));
            Assert.IsTrue(clonedCollection.Contains(new KeyValuePair<string, int>("banana", 2)));

            // проверка, что это разные объекты
            Assert.AreNotSame(testCollections, clonedCollection);
        }

        // проверка метода ShallowCopy, что он создает поверхностную копию коллекции
        [TestMethod]
        public void Test_ShallowCopy()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));

            // Act
            var shallowCopy = testCollections.ShallowCopy();

            // Assert
            Assert.AreEqual(1, shallowCopy.Count); // ожидаем, что количество элементов равно 1
            Assert.IsTrue(shallowCopy.Contains(new KeyValuePair<string, int>("apple", 1)));

            // проверка, что это разные объекты
            Assert.AreNotSame(testCollections, shallowCopy);
        }

        // проверка метода Print, что он корректно выводит содержимое коллекции
        [TestMethod]
        public void Test_Print()
        {
            // Arrange
            testCollections.Add(new KeyValuePair<string, int>("apple", 1));
            testCollections.Add(new KeyValuePair<string, int>("banana", 2));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // перенаправляем вывод в StringWriter

                // Act
                testCollections.Print(); // печатаем коллекцию

                // Assert
                var result = sw.ToString().Trim(); // получаем результат печати
                Assert.IsTrue(result.Contains("apple")); // проверяем, что вывод содержит "apple"
                Assert.IsTrue(result.Contains("banana")); // проверяем, что вывод содержит "banana"
            }
        }
    }
}



