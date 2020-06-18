using static CensusAnalyzer.CsvStatesDao;
using static CensusAnalyzer.StateCensusAnalyserDao;

namespace CensusAnalyzer
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }
        
        /// <summary>
        /// Create csvStateCodedataDao instance
        /// </summary>
        /// <returns></returns>
        public static CsvStateCodeDataDao DelegateOfCsvStates()
        {
            CsvStatesDao csvStateData = InstanceOfCsvStates();
            CsvStateCodeDataDao getStateData = new CsvStateCodeDataDao(CsvStatesDao.CsvStateCodeReadRecord);
            return getStateData;
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