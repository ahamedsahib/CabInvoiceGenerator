using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CabInvoiceTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test fot normal cab ride
        /// </summary>
        [TestMethod]
        public void GetNormalRideFare()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                int time = 5;
                double distance = 10.6, actual, expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        /// <summary>
        /// Test for invalid time
        /// </summary>
        [TestMethod]
        public void TestMethodForInvalidTime()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                int time = 0;
                double distance = 10.6, actual, expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Time is invalid");
            }


        }
        /// <summary>
        /// Test for invalid distance
        /// </summary>
        [TestMethod]
        public void TestMethodForInvalidDistance()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                int time = 5;
                double distance = 0, actual, expected = 111;
                //Act
                actual = getInvoice.GetTotalFare(time, distance);
                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Distance is invalid");
            }


        }
        /// <summary>
        /// Test for aggregate fare 
        /// </summary>
        [TestMethod]
        public void GetAggregateFare()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) };
                double actual, expected = 223;
                //Actaa
                actual = getInvoice.GetAggregateFare(cabRides);

                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
