using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class CsvStatesDao : ICSVBuilder
    {
        public static string stateCodePath = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";

        // variables declaration
        readonly string[] header;
        readonly char delimeter;
        readonly string givenPath;

        // Default Constructor declaration
        public CsvStatesDao()
        {
        }

        // CsvStates parameterised constructor
        public CsvStatesDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCodeDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCodePathObject = new CsvStateCensusReadRecord(stateCodePath);
            var returnObject = stateCodePathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }
        
        /// <summary>
        /// CsvStateDao method 
        /// </summary>
        /// <returns></returns>
        private static CsvStatesDao InstanceOfCsvStates()
        {
            throw new NotImplementedException();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="delimeter"></param>
        /// <param name="givenPath"></param>
        /// <returns></returns>
        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        public object CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }  
}