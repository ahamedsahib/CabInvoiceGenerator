using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoice
    {
        double ratePerKm;
        double minimumCabFare;
        double ratePerMin;

        //Enum to decide type of ride
        public enum RideType
        {
            PREMIUM, NORMAL
        }


        public CabInvoice(RideType type)
        {
            if (type.Equals(RideType.NORMAL))
            {
                ratePerKm = 10;
                minimumCabFare = 5;
                ratePerMin = 1;
            }
            if (type.Equals(RideType.PREMIUM))
            {
                ratePerKm = 15;
                minimumCabFare = 20;
                ratePerMin = 2;
            }


        }
        /// <summary>
        /// method to get total fare of cab ride
        /// </summary>
       
        public double GetTotalFare(int time, double distance)
        {
            double fare = 0;
            try
            {

                if (time <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Time is invalid");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance is invalid");
                }
                //Calculate total fare
                fare = (distance * ratePerKm) + (ratePerMin * time);
                //compare minimum fare and calculated fare return the maximum one
                return Math.Max(fare, minimumCabFare);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public double GetAggregateFare(Ride[] cabRides)
        {
            double aggregateFare = default;
            if (cabRides.Length == 0)
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_RIDE_LIST, "Ride list id invalid");
            foreach (var i in cabRides)
            {
                aggregateFare += GetTotalFare(i.time, i.distance);
            }
            return aggregateFare;
        }
        public string GetInvoiceSummary(Ride[] cabRides)
        {
            double totalFare = GetAggregateFare(cabRides);
            InvoiceSummary summary = new InvoiceSummary(cabRides.Length, totalFare);
            return $"Total number of rides = {summary.totalRides} \n TotalFare ={summary.totalFare} \n AverageFare = {summary.avgFare}";
        }
    }
}
