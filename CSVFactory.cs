using System;
using static CensusAnalyzer.USCensusDataDao;
using static CensusAnalyzer.CsvStatesDao;
using static CensusAnalyzer.StateCensusAnalyserDao;

namespace CensusAnalyzer
{
    public class CSVFactory
    {
        /// <summary>
        ///Method to creating instance of StateCensusAnalyser
        ///Delegate is referance type variable that holds thr referance to the method.
        /// </summary>
        /// <returns></returns>

        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        // Method to creating instance of CsvStates
        public static CsvStateCodeDataDao DelegateOfCsvStates()
        {
            CsvStatesDao csvStateData = InstanceOfCsvStates();
            CsvStateCodeDataDao getStateData = new CsvStateCodeDataDao(CsvStatesDao.CsvStateCodeReadRecord);
            return getStateData;
        }

        // Method to creating instance of USCensusData
        public static CsvUSCensusData DelegateOfUSCensusData()
        {
            USCensusDataDao csvUSData = InstanceOfUSCensusData();
            CsvUSCensusData getUSData = new CsvUSCensusData(USCensusDataDao.CsvUSCensusDataReadRecord);
            return getUSData;
        }

        private static USCensusDataDao InstanceOfUSCensusData()
        {
            throw new NotImplementedException();
        }

        private static CsvStatesDao InstanceOfCsvStates()
        {
            return new CsvStatesDao();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyserDao();
        }
    }
}