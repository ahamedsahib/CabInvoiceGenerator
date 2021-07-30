using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class CabInvoiceCustomException:Exception
    {
        public string message;
        public ExceptionType exceptionType;

       
        public enum ExceptionType
        {
            INVALID_TIME, INVALID_DISTANCE, INVALID_RIDE_LIST
        }

        //Parametrized constructor for custom exception using lambda function
        public CabInvoiceCustomException(ExceptionType exceptionType, string message) : base(message) => this.exceptionType = exceptionType;

    }
}
