using CensusAnalyzer;
using NUnit.Framework;
using static CensusAnalyzer.StateCensusAnalyserDao;
using static CensusAnalyzer.CsvStatesDao;
using static CensusAnalyzer.USCensusDataDao;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        readonly CsvStateCensusDataDao stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDataDao stateCode = CSVFactory.DelegateOfCsvStates();
        readonly CsvUSCensusDataDao USCensus = CSVFactory.DelegateOfUSCensusData();

        // Declaration of FilePath for Valid and Invalid Headers of StateCensusData.
        public string stateCensusDataPath = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        public string wrongStateCensusDataPath = @"C:\Users\HP\source\repos\CensusAnalyzer\WrongIndiaStateCensusData.csv";
        public string wrongStateCensusDataPathExtension = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\IndiaStateCensusData.txt";
        public string[] headerStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] invalidHeaderStateCensus = { "StateInvalid", "Header", "AreaInSqKm", "DensityPerSqKm" };

        // Given File Path of IndiaStateCode valid and invalid.
        public string stateCodePath = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
        public string wrongStateCodePath = @"C:\Users\HP\source\repos\MoodAnalyzer\IndiaStateCode.csv";
        public string wrongExtensionStateCodePath = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.pdf";
        public string[] headerStateCode = { "SrNo", "State", "PIN", "StateCode" };
        public string[] invalidHeaderStateCode = { "SrNo", "State", "PIN", "StateCodeInvalid" };

        // Delimeter declaration.
        readonly char delimeter = ',';
        readonly char IncorrectDelimeter = ';';

        //File path declaration for US census data.
        public string USDataPath = @"C:\Users\HP\source\repos\CensusAnalyzer\USCensusData.csv";
        public string[] headerUSData = { "State Id", "State", "Population", "Housing units", "Total area", "Water area", "Land area", "Population Density", "Housing Density" };

        //Declaration of JSON file path.
        public string stateCensusDataPathJSON = @"C:\Users\HP\source\repos\CensusAnalyzer\StateCensusData.json";
        public string stateCodePathJSON = @"C:\Users\HP\source\repos\CensusAnalyzer\StateCode.json";
        public string usDataPathJSON = @"C:\Users\HP\source\repos\CensusAnalyzer\USDataJSON.json";

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Check for number of records matches or not
        /// If not then generate exception
        /// </summary>
        [Test]
        public void GivenNumberOfRecordsIfMatches_ShouldReturnRecords()
        {
            var numberOfRecords = stateCensus(headerStateCensus, delimeter, stateCensusDataPath);
            Assert.AreEqual(29, numberOfRecords);
        }

        /// <summary>
        /// Check if incorrect file passed.
        /// </summary>
        [Test]
        public void GivenIncorrectCSVFile_ShouldReturnInvalidFile()
        {
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, wrongStateCensusDataPath);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// Check if incorrect extension is passed.
        /// Then it will return Invalid extension of file.
        /// </summary>
        [Test]
        public void GivenInCorrectDotExtensionFile_ShouldReturnInvalidExtension()
        {
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, wrongStateCensusDataPathExtension);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// If incorrect delimeter is passed 
        /// then it will return incorrect delimeter exception.
        /// </summary>
        [Test]
        public void GivenDelimeter_ShouldReturnIncorrectDelimeter()
        {
            object exceptionMessage = stateCensus(headerStateCensus, IncorrectDelimeter, stateCensusDataPath);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <summary>
        /// If invalid header is pass then it will generate exception
        /// like Invalid Header.
        /// </summary>
        [Test]
        public void GivenUserHeader_ShouldReturnInvalidHeader()
        {
            object exceptionMessage = stateCensus(invalidHeaderStateCensus, delimeter, stateCensusDataPath);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <summary>
        /// Check for number of records is matches.
        /// </summary>
        [Test]
        public void GivenNumberOfRecordsMatchesStateCode_ShouldReturnNumberOfRecords()
        {
            var numberOfRecords = stateCode(headerStateCode, delimeter, stateCodePath);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <summary>
        /// Check when incorrect csv file pass
        /// then return Invalid file.
        /// </summary>
        [Test]
        public void GivenInvalidCSVFileStateCode_ShouldReturnIncorrectCSVFile()
        {
            object exceptionMessage = stateCode(headerStateCode, delimeter, wrongStateCodePath);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// check when user pass invalid extension
        /// then generate exception.
        /// </summary>
        [Test]
        public void GiveExtensionFileStateCode_ShouldReturnInvalidExtension()
        {
            object exceptionMessage = stateCode(headerStateCode, delimeter, wrongExtensionStateCodePath);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// Check if imported file's extension is incorrect
        /// then generate the exception.
        /// </summary>
        [Test]
        public void GivenDelimeterStateCode_ShouldReturnIncorrectDelimeter()
        {
            object exceptionMessage = stateCode(headerStateCode, IncorrectDelimeter, stateCodePath);
            Assert.AreEqual("Invalid Delimeter", exceptionMessage);
        }

        /// <summary>
        /// If header is not same then generate the exception
        /// </summary>
        [Test]
        public void GivenHeaderOfStateCode_ShouldReturnInvalidHeader()
        {
            object exceptionMessage = stateCode(invalidHeaderStateCode, delimeter, stateCodePath);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <summary>
        /// Check for return first state name.
        /// after sorting.
        /// </summary>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSorting_ShouldReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusPath, stateCensusDataPathJSON, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        ///  /// Check for return last state name.
        /// after sorting.
        /// </summary>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSorting__ShouldReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusPath, stateCensusDataPathJSON, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        ///check for StateCodeCsv and json path to add into json after sorting return return first stateCode.
        /// </summary>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSorting_ShouldReturnFirstStateCode()
        {
            string expected = "AD";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCodePath, stateCodePathJSON, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 14>
        /// check for StateCodeCsv and json path to add into json after sorting return return last stateCode.
        /// </Test 14>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSorting_ShouldReturnLastStateCode()
        {
            string expected = "WB";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCodePath, stateCodePathJSON, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 15>
        ///Check for StateCensuscsv and json path to add into json after sorting return most Population.
        /// </Test 15>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromMostPopulousToLeast_ShouldReturnTotalStatesSorted()
        {
            string expected = "199812341";
            string mostPopulation = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(stateCensusPath, stateCensusDataPathJSON, "Population");
            Assert.AreEqual(expected, mostPopulation);
        }

        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromMostLeastToPopulous_ShouldReturnTotalSortedStates()
        {
            string expected = "607688";
            string mostPopulation = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, stateCensusDataPathJSON, "Population");
            Assert.AreEqual(expected, mostPopulation);
        }

        /// Check for StateCensusCSV & json path to add into json after sorting return most Population.
        //Return density most populated density in per sq km.
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromMostDensityPerKmLeast_ShouldReturnDensityPerSqKm()
        {
            string expected = "1102";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(stateCensusPath, stateCodePathJSON, "DensityPerSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }

        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromLeastDensityPerKmMost_ShouldReturnDensityPerSqKm()
        {
            string expected = "50";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, stateCensusDataPathJSON, "DensityPerSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }
        /// <Test 19>
        /// Test for StateCensuscsv and json path to add into json after sorting return most AreaInSqKm.
        /// </Test 19>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromMostAreaInSqKmToLeast_ShouldReturnAreaInSqKmv()
        {
            string expected = "342239";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(stateCensusPath, stateCensusDataPathJSON, "AreaInSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }
        /// <Test 20>
        /// Test for StateCensuscsv and json path to add into json after sorting return Least AreaInSqKm.
        /// </Test 20>
        [Test]
        public void GivenStateCensusDataAndAddToJsonPathAndSortFromLeastAreaInSqKmToMost_ReturnAreaInSqKmv()
        {
            string expected = "3702";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, stateCensusDataPathJSON, "AreaInSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }

        [Test]
        public void GivenUSCensusData_ShouldReturnNumberOFRecords()
        {
            var returnRecords = USCensus;
            Assert.AreEqual(51, returnRecords);
        }

        /// <Test 22>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning most populus number.
        /// </Test 22>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromMostPopulousToLeast_ReturnMostPolulation()
        {
            string expected = "37253956";
            string mostPopulus = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Population");
            Assert.AreEqual(expected, mostPopulus);
        }

        /// <Test 23>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning least populus number.
        /// </Test 23>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromLeastPopulousToMost_ReturnLeastPopulation()
        {
            string expected = "563626";
            string leastPopulation = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Population");
            Assert.AreEqual(expected, leastPopulation);
        }

        /// <Test 24>
        ///  Test for USCensuscsv and json path to add into json after sorting return return first state.
        /// </Test 24>
        [Test]
        public void GivenUSCensusDataAndAddToJsonPathAndSorting_ReturnFirstState()
        {
            string expected = "Alabama";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(USDataPath, usDataPathJSON, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 25>
        ///  Test for USCensuscsv and json path to add into json after sorting return return last state.
        /// </Test 25>
        [Test]
        public void GivenUSCensusDataAndAddToJsonPathAndSorting_ReturnLastState()
        {
            string expected = "Wyoming";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(USDataPath, usDataPathJSON, "State");
            Assert.AreEqual(expected, lastValue);
        }

        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromMostPopulousDensityToLeast_ReturnMostPopulationDensity()
        {
            string expected = "3805.61";
            string mostPopulationDensity = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Population Density");
            Assert.AreEqual(expected, mostPopulationDensity);
        }

        /// <Test 27>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning least populus density.
        /// </Test 27>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromLeastPopulousDEnsityToMost_ReturnLeastPopulationDensity()
        {
            string expected = "0.46";
            string leastPopulationDensity = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Population Density");
            Assert.AreEqual(expected, leastPopulationDensity);
        }

        /// <Test 28>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning Highest Total area.
        /// </Test 28>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromMostTotalAreaToLeast_ReturnMostTotalArea()
        {
            string expected = "1723338.01";
            string mostTotalArea = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Total area");
            Assert.AreEqual(expected, mostTotalArea);
        }

        /// <Test 29>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning Lowest Total area.
        /// </Test 28>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromLeastTotalAreaToMost_ReturnLeastTotalArea()
        {
            string expected = "177";
            string mostTotalArea = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(USDataPath, usDataPathJSON, "Total area");
            Assert.AreEqual(expected, mostTotalArea);
        }
    }
}