using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class StateCensusException : Exception
    {
        public enum TypeOfExceptions
        {
            INCORRECT_FILE, FILE_NOT_FOUND, NAME_IS_NOT_CORRECT, INCORRECT_DELIMETER, INCORRECT_HEADER,
            HEADER_NAME_NOT_CORRECT, HEADER_LENGTH_NOT_EQUAL, FILE_CONTAIN_NO_DATA,
        }
        public TypeOfExceptions type;
        public StateCensusException(TypeOfExceptions type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
