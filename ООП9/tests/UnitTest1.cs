using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ООП9;

namespace tests
{
    [TestClass]
    public class InputTests
    {
        Help Help = new Help();
        [TestMethod]
        public void InputInt_ValidInput_ReturnsNumber()
        {
            // Arrange
            string input = "42";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);


            // Act
            int result = Help.InputInt();

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void InputInt_InvalidInput_PromptsAgain()
        {
            // Arrange
            string input = "abc\n10";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            int result = Help.InputInt();

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void InputInt_WithRange_ValidInput_ReturnsNumberInRange()
        {
            // Arrange
            string input = "5"; // Корректный ввод
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            int result = Help.InputInt(1, 10);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void InputInt_WithRange_InvalidInput_PromptsAgain()
        {
            // Arrange
            string input = "15\n5";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            int result = Help.InputInt(1, 10);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void InputInt_WithRange_BoundaryValues_ReturnsCorrectNumber()
        {
            // Arrange for lower boundary
            string input = "1";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            int result = Help.InputInt(1, 10);

            // Assert
            Assert.AreEqual(1, result);

            // Arrange for upper boundary
            input = "10";
            stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            result = Help.InputInt(1, 10);

            // Assert
            Assert.AreEqual(10, result);
        }

    }
    [TestClass]
    public class TimeTests
    {
        Time Time = new Time();
        [TestMethod]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            int initialCount = Time.count;

            // Act
            Time time = new Time(10, 30);

            // Assert
            Assert.AreEqual(10, time.GetHH());
            Assert.AreEqual(30, time.GetMM());
            Assert.AreEqual(initialCount + 1, Time.count);
        }

        [TestMethod]
        public void GetTime_ShouldReturnNewTimeInstance()
        {
            // Arrange
            Time time = new Time(10, 30);
            int initialCount = Time.count;

            // Act
            Time newTime = time.GetTime();

            // Assert
            Assert.AreEqual(10, time.GetHH());
            Assert.AreEqual(30, time.GetMM());
            Assert.AreEqual(initialCount, Time.count);
        }

        [TestMethod]
        public void SetTime_ShouldUpdateTime()
        {
            // Arrange
            Time time = new Time(10, 30);

            // Act
            time.SetTime(12, 45);

            // Assert
            Assert.AreEqual(12, time.GetHH());
            Assert.AreEqual(45, time.GetMM());
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            Time time = new Time(10, 30);
            Time negativeTime = new Time(-1, -30);

            // Act
            string timeString = time.ToString();
            string negativeTimeString = negativeTime.ToString();

            // Assert
            Assert.AreEqual("10:30", timeString);
            Assert.AreEqual("- 01:30", negativeTimeString);
        }

        [TestMethod]
        public void ImplicitOperator_ShouldConvertToMinutes()
        {
            // Arrange
            Time time = new Time(1, 30);

            // Act
            int totalMinutes = time;

            // Assert
            Assert.AreEqual(90, totalMinutes);
        }

        [TestMethod]
        public void ExplicitOperator_ShouldReturnTrueIfNotZero()
        {
            // Arrange
            Time time = new Time(1, 0);

            // Act
            bool isNotZero = (bool)time;

            // Assert
            Assert.IsFalse(isNotZero);
        }

        [TestMethod]
        public void OperatorLessThan_ShouldWorkCorrectly()
        {
            // Arrange
            Time time1 = new Time(1, 0);
            Time time2 = new Time(2, 0);

            // Act
            bool result = time1 < time2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorGreaterThan_ShouldWorkCorrectly()
        {
            // Arrange
            Time time1 = new Time(2, 0);
            Time time2 = new Time(1, 0);

            // Act
            bool result = time1 > time2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorDecrement_ShouldWorkCorrectly()
        {
            // Arrange
            Time time = new Time(0, 0);

            // Act
            Time newTime = --time;

            // Assert
            Assert.AreEqual(23, time.GetHH());
            Assert.AreEqual(59, time.GetMM());
        }

        [TestMethod]
        public void OperatorIncrement_ShouldWorkCorrectly()
        {
            // Arrange
            Time time = new Time(23, 59);

            // Act
            Time newTime = ++time;

            // Assert
            Assert.AreEqual(0, time.GetHH());
            Assert.AreEqual(0, time.GetMM());
        }

        [TestMethod]
        public void SubtractingSecondFromFirstStatic_ShouldReturnCorrectResult()
        {
            // Arrange
            Time time1 = new Time(2, 0);
            Time time2 = new Time(1, 30);

            // Act
            Time result = Time.SubtractingSecondFromFirstStatic(time1, time2);

            // Assert
            Assert.AreEqual(0, result.GetHH());
            Assert.AreEqual(30, result.GetMM());
        }

        [TestMethod]
        public void SubtractingSecondFromFirstMethod_ShouldReturnCorrectResult()
        {
            // Arrange
            Time time1 = new Time(2, 0);
            Time time2 = new Time(1, 30);

            // Act
            Time result = time1.SubtractingSecondFromFirstMethod(time2);

            // Assert
            Assert.AreEqual(0, result.GetHH());
            Assert.AreEqual(30, result.GetMM());
        }
    }
    [TestClass]
    public class TimeArrayTests
    {

        TimeArray TimeArray = new TimeArray();
        [TestMethod]
        public void Constructor_WithoutParameters_ShouldInitializeEmptyArray()
        {
            // Act
            TimeArray timeArray = new TimeArray();

            // Assert
            Assert.AreEqual(0, timeArray.Length);
        }

        [TestMethod]
        public void Constructor_WithSize_ShouldInitializeArrayWithGivenSize()
        {
            // Act
            TimeArray timeArray = new TimeArray(3, true);

            // Assert
            Assert.AreEqual(3, timeArray.Length);
        }

        [TestMethod]
        public void Indexer_ShouldReturnCorrectTime()
        {
            // Arrange
            TimeArray timeArray = new TimeArray(3, true);
            timeArray[0] = new Time(1, 30);
            timeArray[1] = new Time(2, 15);
            timeArray[2] = new Time(0, 45);

            // Act
            Time time = timeArray[1];

            // Assert
            Assert.AreEqual(2, time.GetHH());
            Assert.AreEqual(15, time.GetMM());
        }

        [TestMethod]
        public void Indexer_ShouldThrowException_WhenIndexOutOfRange()
        {
            // Arrange
            TimeArray timeArray = new TimeArray(3, true);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => { var time = timeArray[5]; });
            Assert.ThrowsException<IndexOutOfRangeException>(() => { timeArray[-1] = new Time(1, 0); });
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            TimeArray timeArray = new TimeArray(3, true);
            timeArray[0] = new Time(1, 30);
            timeArray[1] = new Time(2, 15);
            timeArray[2] = new Time(0, 45);

            // Act
            string result = timeArray.ToString();

            // Assert
            Assert.AreEqual("01:30\n02:15\n00:45\n", result);
        }

        [TestMethod]
        public void ToString_ShouldThrowException_WhenArrayIsEmpty()
        {
            // Arrange
            TimeArray timeArray = new TimeArray();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => timeArray.ToString());
        }

        [TestMethod]
        public void MaxTime_ShouldReturnCorrectMaxTime()
        {
            // Arrange
            TimeArray timeArray = new TimeArray(3, true);
            Time maxTime = new Time();

            timeArray[0] = new Time(1, 30);
            timeArray[1] = new Time(2, 15);
            timeArray[2] = new Time(0, 45);

            // Act
            maxTime = timeArray.MaxTime();

            // Assert
            Assert.AreEqual(2, maxTime.GetHH());
            Assert.AreEqual(15, maxTime.GetMM());
        }
    }
}
