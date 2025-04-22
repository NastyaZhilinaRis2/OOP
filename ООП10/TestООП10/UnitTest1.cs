using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ООП10Library;

namespace ООП10Library.Tests
{
    [TestClass]
    public class GoodsTests
    {
        [TestMethod]
        public void TestConstructorAndProperties()
        {
            var goods = new Goods("Товар1", 100.50m, 10);
            Assert.AreEqual("Товар1", goods.Name);
            Assert.AreEqual(100.50m, goods.Price);
            Assert.AreEqual(10, goods.AmountGoods);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPriceLessThanZero()
        {
            var goods = new Goods();
            goods.Price = -1; // Это должно вызвать исключение
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPriceGreaterThanLimit()
        {
            var goods = new Goods();
            goods.Price = 100001; // Это должно вызвать исключение
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountLessThanZero()
        {
            var goods = new Goods();
            goods.AmountGoods = -1; // Это должно вызвать исключение
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountGreaterThanLimit()
        {
            var goods = new Goods();
            goods.AmountGoods = 100001; // Это должно вызвать исключение
        }

        [TestMethod]
        public void TestClone()
        {
            var goods = new Goods("Товар2", 150.75m, 5);
            var clonedGoods = (Goods)goods.Clone();

            Assert.AreEqual(goods.Name, clonedGoods.Name);
            Assert.AreEqual(goods.Price, clonedGoods.Price);
            Assert.AreEqual(goods.AmountGoods, clonedGoods.AmountGoods);
            Assert.IsFalse(ReferenceEquals(goods.ReferenceType, clonedGoods.ReferenceType)); // Проверяем глубокое копирование
        }

        [TestMethod]
        public void TestComparison()
        {
            var goods1 = new Goods("Товар1", 200.00m, 15);
            var goods2 = new Goods("Товар1", 200.00m, 15);
            var goods3 = new Goods("Товар5", 100.00m, 20);

            Assert.AreEqual(0, goods1.CompareTo(goods2)); // Должны быть равны
            Assert.IsTrue(goods1.CompareTo(goods3) < 0); // goods1 должен быть больше goods3
            Assert.IsTrue(goods3.CompareTo(goods1) > 0); // goods3 должен быть меньше goods1
        }

        [TestMethod]
        public void TestEquals()
        {
            var goods1 = new Goods("Товар6", 300.00m, 25);
            var goods2 = new Goods("Товар6", 300.00m, 25);
            var goods3 = new Goods("Товар7", 150.00m, 10);

            Assert.IsTrue(goods1.Equals(goods2)); // Должны быть равны
            Assert.IsFalse(goods1.Equals(goods3)); // Не равны
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            var goods1 = new Goods("Товар8", 400.00m, 30);
            var goods2 = new Goods("Товар8", 400.00m, 30);
            var goods3 = new Goods("Товар9", 500.00m, 40);

            Assert.AreEqual(goods1.GetHashCode(), goods2.GetHashCode()); // Должны быть равны
            Assert.AreNotEqual(goods1.GetHashCode(), goods3.GetHashCode()); // Не равны
        }
    }
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestConstructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            string expectedName = "Продукт";
            decimal expectedPrice = 20.99m;
            int expectedAmount = 10;
            string expectedComposition = "Состав1";
            int expectedExpirationDate = 30;

            // Act
            Product product = new Product(expectedName, expectedPrice, expectedAmount, expectedComposition, expectedExpirationDate);

            // Assert
            Assert.AreEqual(expectedName, product.Name);
            Assert.AreEqual(expectedPrice, product.Price);
            Assert.AreEqual(expectedAmount, product.AmountGoods);
            Assert.AreEqual(expectedComposition, product.Composition);
            Assert.AreEqual(expectedExpirationDate, product.ExpirationDate);
        }

        [TestMethod]
        public void TestConstructor_WithNegativeExpirationDate_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            string name = "Продукт";
            decimal price = 20.99m;
            int amount = 10;
            string composition = "Состав1";
            int expirationDate = -5;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product(name, price, amount, composition, expirationDate));
        }

        [TestMethod]
        public void TestClone_ShouldReturnNewInstanceWithSameValues()
        {
            // Arrange
            Product original = new Product("Продукт", 20.99m, 10, "Состав1", 30);

            // Act
            Product cloned = (Product)original.Clone();

            // Assert
            Assert.AreNotSame(original, cloned);
            Assert.AreEqual(original.Name, cloned.Name);
            Assert.AreEqual(original.Price, cloned.Price);
            Assert.AreEqual(original.AmountGoods, cloned.AmountGoods);
            Assert.AreEqual(original.Composition, cloned.Composition);
            Assert.AreEqual(original.ExpirationDate, cloned.ExpirationDate);
        }

        [TestMethod]
        public void TestCompareTo_WithSameValues_ShouldReturnZero()
        {
            // Arrange
            Product product1 = new Product("Продукт", 20.99m, 10, "Состав1", 30);
            Product product2 = new Product("Продукт", 20.99m, 10, "Состав1", 30);

            // Act
            int comparisonResult = product1.CompareTo(product2);

            // Assert
            Assert.AreEqual(0, comparisonResult);
        }

        [TestMethod]
        public void TestCompareTo_WithDifferentCompositions_ShouldReturnPositiveOrNegative()
        {
            // Arrange
            Product product1 = new Product("Продукт", 20.99m, 10, "Состав1", 30);
            Product product2 = new Product("Продукт", 20.99m, 10, "Состав2", 30);

            // Act
            int comparisonResult = product1.CompareTo(product2);

            // Assert
            Assert.IsTrue(comparisonResult < 0);
        }

        [TestMethod]
        public void TestCompareTo_WithDifferentExpirationDates_ShouldReturnPositiveOrNegative()
        {
            // Arrange
            Product product1 = new Product("Продукт", 20.99m, 10, "Состав1", 40);
            Product product2 = new Product("Продукт", 20.99m, 10, "Состав1", 30);

            // Act
            int comparisonResult = product1.CompareTo(product2);

            // Assert
            Assert.IsTrue(comparisonResult > 0);
        }

        [TestMethod]
        public void TestToString_ShouldReturnExpectedString()
        {
            // Arrange
            Product product = new Product("Продукт", 20.99m, 10, "Состав1", 30);
            string expectedString = $"Продукт         20.99  руб.     10    шт.     Состав1             30  дня(ей)      ";

            // Act
            string result = product.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }
    [TestClass]
    public class MilkProductTests
    {
        [TestMethod]
        public void MilkProduct_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var name = "Молоко";
            var price = 25.50m;
            var amountGoods = 10;
            var composition = "Молоко";
            var expirationDate = 30;
            var isNoLactose = true;
            var isNoMilkFat = false;

            // Act
            var milkProduct = new MilkProduct(name, price, amountGoods, composition, expirationDate, isNoLactose, isNoMilkFat);

            // Assert
            Assert.AreEqual(name, milkProduct.Name);
            Assert.AreEqual(price, milkProduct.Price);
            Assert.AreEqual(amountGoods, milkProduct.AmountGoods);
            Assert.AreEqual(composition, milkProduct.Composition);
            Assert.AreEqual(expirationDate, milkProduct.ExpirationDate);
            Assert.AreEqual(isNoLactose, milkProduct.IsNoLactose);
            Assert.AreEqual(isNoMilkFat, milkProduct.IsNoMilkFat);
        }

        [TestMethod]
        public void MilkProduct_Clone_ShouldReturnEqualObject()
        {
            // Arrange
            var original = new MilkProduct("Молоко", 25.50m, 10, "Молоко", 30, true, false);

            // Act
            var clone = (MilkProduct)original.Clone();

            // Assert
            Assert.AreNotSame(original, clone);
            Assert.AreEqual(original.Name, clone.Name);
            Assert.AreEqual(original.Price, clone.Price);
            Assert.AreEqual(original.AmountGoods, clone.AmountGoods);
            Assert.AreEqual(original.Composition, clone.Composition);
            Assert.AreEqual(original.ExpirationDate, clone.ExpirationDate);
            Assert.AreEqual(original.IsNoLactose, clone.IsNoLactose);
            Assert.AreEqual(original.IsNoMilkFat, clone.IsNoMilkFat);
        }

        [TestMethod]
        public void MilkProduct_ToString_ShouldReturnCorrectString()
        {
            // Arrange
            var milkProduct = new MilkProduct("Молоко", 25.50m, 10, "Молоко", 30, true, false);
            var expectedString = $"Молоко          25.50  руб.     10    шт.     Молоко              30  дня(ей)      True  False ";

            // Act
            var result = milkProduct.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void MilkProduct_CompareTo_ShouldReturnCorrectComparison()
        {
            // Arrange
            var milkProduct1 = new MilkProduct("Молоко 1", 25.50m, 10, "Молоко", 30, true, false);
            var milkProduct2 = new MilkProduct("Молоко 2", 25.50m, 10, "Молоко", 30, false, false);
            var milkProduct3 = new MilkProduct("Молоко 3", 30.00m, 10, "Молоко", 30, true, false);

            // Act
            var result1 = milkProduct1.CompareTo(milkProduct2); // milkProduct1 должен быть меньше, так как IsNoLactose == true
            var result2 = milkProduct1.CompareTo(milkProduct3); // milkProduct1 должен быть меньше, так как цена меньше

            // Assert
            Assert.IsTrue(result1 < 0);
            Assert.IsTrue(result2 < 0);
        }

        [TestMethod]
        public void MilkProduct_Show_ShouldOutputCorrectString()
        {
            // Arrange
            var milkProduct = new MilkProduct("Молоко", 25.50m, 10, "Молоко", 30, true, false);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                milkProduct.Show();
                var result = sw.ToString().Trim();

                // Assert
                var expectedString = $"Название: Молоко\nЦена: 25.50 руб.\nКоличество: 10 шт.\r\nСостав: Молоко\nДо конца срока годности: 30 дня(ей)\r\nБез лактозы: True\nБМЖ: False";
                Assert.AreEqual(expectedString, result);
            }
        }
    }
}
