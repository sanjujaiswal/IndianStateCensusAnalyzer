using System;

namespace CensusAnalyzer
{
    public class StateCensusAnalyserDao : ICSVBuilder
    {
        static void Main1(string[] args)
        {
        }
        public static string stateCensusPath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
        // variables declaration
        string[] header;
        char delimeter;
        string givenPath;

        // Main Method
       //end: static void Main(string[] args)

        // Default Constructor
        public StateCensusAnalyserDao()
        {
        }

        // CsvStates parameterised constructor
        public StateCensusAnalyserDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCensusDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'CensusReadRecord' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCensusPathObject = new CsvStateCensusReadRecord(stateCensusPath);
            var returnObject = stateCensusPathObject.ReadRecords(header, delimeter, givenPath);
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
    }
}
