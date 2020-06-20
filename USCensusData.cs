using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class USCensusDataDao : ICSVBuilder
    {
        public static string USDataPath = @"C:\Users\HP\source\repos\CensusAnalyzer\USCensusData.csv";
        
        //Declarations of variables
        public string stateCensusFilePath { get; set; }
        public char delimeter { get; set; }
        public string[] header { get; set; }
        public string givenPath { get; set; }

        // For Default Constructor
        public USCensusDataDao()
        {
        }

        //Parameterised constructor for csvStates.
        public USCensusDataDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvUSCensusData(string[] header, char delimeter, string givenPath);

        /// <summary>
        /// Crating object as usCensusDataPathObject 
        /// and the return object is returned to test case.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="delimeter"></param>
        /// <param name="givenPath"></param>
        /// <returns></returns>
        public static object CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord usCensusDataPathObject = new CsvStateCensusReadRecord(USDataPath);
            var returnObject = usCensusDataPathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }
}
