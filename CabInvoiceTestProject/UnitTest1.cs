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
        /// <summary>
        /// Test Method to get summary of invoice
        /// </summary>
        [TestMethod]
        public void GetInvoiceSummary()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) };
                string actual, expected = "Total number of rides = 2 \n TotalFare =223 \n AverageFare = 111.5";
                //Act
                actual = getInvoice.GetInvoiceSummary(cabRides);

                //Assert
                Assert.AreEqual(actual, expected);

            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        [TestMethod]
        public void GetPremiumRideFare()
        {
            try
            {
                //Arrange
                CabInvoice getInvoice = new CabInvoice(CabInvoice.RideType.PREMIUM);
                int time = 5;
                double distance = 10.6, actual, expected = 169;
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
        [TestMethod]
        public void SearchUser()
        {
            try
            {
                //Arrange
                //array for rides
                Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) };
                UserRideData rideRepository = new UserRideData();
                //add summary to dictonaries
                rideRepository.AddUserToDIctionary(001, cabRides, CabInvoice.RideType.NORMAL);
                rideRepository.AddUserToDIctionary(001, cabRides, CabInvoice.RideType.PREMIUM);
                rideRepository.AddUserToDIctionary(002, cabRides, CabInvoice.RideType.PREMIUM);
                string actual, expected = "User Id :1\nNormal\nTotal number of rides = 2\nTotalFare = 223\nAverageFare = 111.5\n*****************\nPremium\nTotal number of rides = 2\nTotalFare = 340\nAverageFare = 170\n*****************\n";
                //Act
                actual = rideRepository.SearchUser(001);

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
