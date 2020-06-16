using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
        public class CSVException : Exception
        {
            // exception variable declared
            ExceptionType exception;

            // enum declaration to give constant value
            public enum ExceptionType
            {
                FILE_IS_EMPTY
            }

            public CSVException(ExceptionType exception, string message) : base(message)
            {
                this.exception = exception;
            }
        }
    }