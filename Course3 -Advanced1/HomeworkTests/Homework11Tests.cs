using Homework11;
using Homework11.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HomeworkTests
{
    [TestClass]
    public class Homework11Tests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<int>))]
        public void TestGenericIntMaxRangeIsReached()
        {
            GenericRangedList<int> list = new GenericRangedList<int>(0, 1000);
            list.AddRanged(9999);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<int>))]
        public void TestGenericIntMinRangeIsReached()
        {
            GenericRangedList<int> list = new GenericRangedList<int>(0, 1000);
            list.AddRanged(-9999);
        }

        [TestMethod]
        public void TestIntListGeneric()
        {
            try
            {
                GenericRangedList<int> list = new GenericRangedList<int>(0, 1000);
                list.AddRanged(1);
                list.AddRanged(2);
                list.AddRanged(3);
                list.AddRanged(4);          
            }
            catch (InvalidRangeException<int> ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        
        
        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<DateTime>))]
        public void TestGenericDateTimeMaxRangeIsReached()
        {
            GenericRangedList<DateTime> listDates = new GenericRangedList<DateTime>(DateTime.Now, new DateTime(2020, 01, 01, 00, 00, 00));
            listDates.AddRanged(DateTime.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<DateTime>))]
        public void TestGenericDateTimeMinRangeIsReached()
        {
            GenericRangedList<DateTime> listDates = new GenericRangedList<DateTime>(DateTime.Now, new DateTime(2020, 01, 01, 00, 00, 00));
            listDates.AddRanged(DateTime.MinValue);
        }

        [TestMethod]
        public void TestDateTimeListGeneric()
        {
            try
            {
                GenericRangedList<DateTime> listDates = new GenericRangedList<DateTime>(DateTime.Now, new DateTime(2020, 01, 01, 00, 00, 00));

                listDates.AddRanged(new DateTime(2019, 12, 5));
                listDates.AddRanged(new DateTime(2019, 12, 7));
                listDates.AddRanged(new DateTime(2019, 12, 15));
            }
            catch (InvalidRangeException<int> ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}