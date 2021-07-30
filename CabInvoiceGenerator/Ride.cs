using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class Ride
    {
        public int time;
        public double distance;

       
        public Ride(int time, double distance)
        {
            this.time = time;
            this.distance = distance;
        }
    }
}
