using Homework10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace HomeworkTests
{
    [TestClass]
    public class Homework10Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSumOnEmptyList()
        {
            IEnumerable<int> ints = new List<int>();
            ints.Sum();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProductOnEmptyList()
        {
            IEnumerable<int> ints = new List<int>();
            ints.Product();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMinOnEmptyList()
        {
            IEnumerable<int> ints = new List<int>();
            ints.Min();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMaxOnEmptyList()
        {
            IEnumerable<int> ints = new List<int>();
            ints.Max();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAverageOnEmptyList()
        {
            IEnumerable<int> ints = new List<int>();
            ints.Average();
        }


        [TestMethod]
        public void TestIntegerFlow()
        {
            IEnumerable<int> ints = new List<int> { 1, 4, 3, 2 };

            Assert.AreEqual(10, ints.Sum());
            Assert.AreEqual(24, ints.Product());
            Assert.AreEqual(1, ints.Min());
            Assert.AreEqual(4, ints.Max());
            
            Assert.AreEqual(2, Math.Round((decimal)ints.Average()));
        }

        [TestMethod]
        public void TestFloatFlow()
        {
            IEnumerable<float> floats = new List<float> { 1.1f, 2.1f, 3.1f, 4.1f, 5.1f, 6.1f };

            Assert.AreEqual(21.6, Math.Round(floats.Sum(),2));
            Assert.AreEqual(913.39, Math.Round(floats.Product(),2));
            Assert.AreEqual(1.1, Math.Round(floats.Min(), 1));
            Assert.AreEqual(6.1, Math.Round(floats.Max(), 1));
            Assert.AreEqual(3.60, Math.Round(floats.Average(), 2));
        }

        [TestMethod]
        public void TestDoubleFlow()
        {
            IEnumerable<double> doubles = new List<double> { 1.2, 2.2, 3.2, 4.2, 5.2, 6.2 };

            Assert.AreEqual(22.2, Math.Round(doubles.Sum(), 2));
            Assert.AreEqual(1143.93, Math.Round(doubles.Product(), 2));
            Assert.AreEqual(1.2, Math.Round(doubles.Min(), 1));
            Assert.AreEqual(6.2, Math.Round(doubles.Max(), 1));
            Assert.AreEqual(3.70, Math.Round(doubles.Average(), 2));
        }

        [TestMethod]
        public void TestDecimalsFlow()
        {
            IEnumerable<decimal> decimals = new List<decimal> { 1.5M, 2.5M, 3.5M, 4.5M, 5.5M, 6.5M };

            Assert.AreEqual(24.00M, Math.Round(decimals.Sum(), 2));
            Assert.AreEqual(2111.48M, Math.Round(decimals.Product(), 2));
            Assert.AreEqual(1.5M, Math.Round(decimals.Min(), 1));
            Assert.AreEqual(6.5M, Math.Round(decimals.Max(), 1));
            Assert.AreEqual(4.0M, Math.Round(decimals.Average(), 2));
        }

        [TestMethod]
        public void TestWrongTypeForSum()
        {
            IEnumerable<string> ints = new List<string> { "abc", "def" };
            try
            {
                ints.Sum();
                Assert.Fail();
            }
            catch { }
        }

        [TestMethod]
        public void TestWrongTypeForProduct()
        {
            IEnumerable<DateTime> ints = new List<DateTime> { DateTime.Now, new DateTime(2019, 12, 10) };
            try
            {
                ints.Product();
                Assert.Fail();
            }
            catch { }
        }

        [TestMethod]
        public void TestWrongTypeForAverage()
        {
            IEnumerable<string> ints = new List<string> { "abc", "def" };
            try
            {
                ints.Average();
                Assert.Fail();
            }
            catch { }
        }

        //....

    }
}