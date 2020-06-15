using CensusAnalyzer;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        StateCensusAnalyser read = new StateCensusAnalyser(pathStateData);

        [SetUp]
        public void Setup()
        {
        }

        /// Test 1
        [Test]
        public void CheckNumberOfRecordMatches()
        {
            int record = read.csvFileReadMethod(',');
            Assert.AreEqual(29, record);
        }

        //Test 2
        [Test]
        public void CheckFileNotFoundException()
        {
            try
            {
                string path = @"C:\Users\HP\source\repos\CabServices\IndiaStateCensusData.csv";
                StateCensusAnalyser read = new StateCensusAnalyser(path);
                int record = read.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File is not present here", e.Message);
            }
        }

        [Test]
        public void CheckWrongFileType()
        {
            try
            {
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.txt";
                StateCensusAnalyser read = new StateCensusAnalyser(path);
                int record = read.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }

        //Test3
        [Test]
        public void CheckIncorrectDelimeter()
        {
            try
            {
                int record = read.csvFileReadMethod(';');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }

        //Test4
        [Test]
        public void CheckIncorrectHeaderNames()
        {
            try
            {
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "AreaInKm", "DensitySqKm" };
                string[] header = read.numberOfHeader(enteredHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Header name is not right", e.Message);
            }
        }

        //Test 5 
        [Test]
        public void IncorrectHeaderLength()
        {
            try
            {
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "DensityPerSqKm" };
                string[] header = read.numberOfHeader(enteredHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Header length is not equal", e.Message);
            }
        }
    }
    public class CSVStateCode
    {
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
        CSVStateCensus readCSVStateCode = new CSVStateCensus(pathStateData);

        [SetUp]
        public void SetUp()
        {
        }
        // Test 1
        [Test]
        public void TotalRecordInCSVStateCode()
        {
            int record = readCSVStateCode.csvFileReadMethod(',');
            Assert.AreEqual(37, record);
        }

        [Test]
        public void FileNotFoundOfCSVStateCode()
        {
            try
            {
                string Path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                CSVStateCensus readCSVStateCode = new CSVStateCensus(Path);
                int record = readCSVStateCode.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File is not present here", e.Message);
            }
        }

        [Test]
        public void WrongFileTypeOfCSVStateCode()
        {
            try
            {
                string Path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                CSVStateCensus readCSVStateCode = new CSVStateCensus(Path);
                int record = readCSVStateCode.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }

        [Test]
        public void WrongDelimeterOfCSVStateCode()
        {
            try
            {
                int record = readCSVStateCode.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }

        [Test]
        public void WrongHeaderOfCSVStateCode()
        {
            try
            {
                string[] expectedHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] userHeader = { "SrNo", "State Name", "TIN", "State" };
                string[] header = readCSVStateCode.numberOfHeader(userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], userHeader[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Header name is not right", e.Message);
            }
        }

        [Test]
        public void WrongHeaderLengthOfCSVStateCode()
        {
            try
            {
                string[] expectedHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] userHeader = { "SrNo", "State Name", "TIN" };
                string[] header = readCSVStateCode.numberOfHeader(userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], userHeader[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Header length is not equal", e.Message);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CsvStateDataUsing_CsvBuilder
    {
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        [SetUp]
        public void Setup()
        {

        }
        /*
        [Test]
        public void checkForHeadersInCsvData()
        {
            string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            int jsonForm = 1;
            int sorting = 1;
            int columnNumber = 0;

            CSVBuilder state = new CSVBuilder(pathStateData, jsonForm, sorting, columnNumber);
            var output = state.getHeaders();

            for (int i = 0; i < expectedHeader.Length; i++)
            { 
                Assert.AreEqual(expectedHeader[i], output[i]);
            }

        }
        */

        [Test]
        public void FirstStateIn_CsvData()
        {
            var expectedState = "Andhra Pradesh";
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 0;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var firstState = state.getSortedRecords();
            firstState = firstState[0];
            Assert.AreEqual(expectedState, firstState);
        }

        [Test]
        public void LastStateIn_CsvData()
        {
            var expectedState = "West Bengal";
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 0;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);

            var lastState = state.getSortedRecords();
            var LastStateName = state.getSortedRecords();

            lastState = lastState[lastState];
            Assert.AreEqual(expectedState, LastStateName);
        }

        [Test]
        public void TotalRecordsIn_CsvData()
        {
            int jasonForm = 1;
            int sorting = 1;
            int columnNumber = 0;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var numberOfRecord = state.getSortedRecords();
            Assert.AreEqual(29, numberOfRecord);
        }

        [Test]
        public void FirstStateIn_JSONFormate()
        {
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 0;
            CSVData csvStates = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var sortedInJsonFormate = csvStates.getSortedRecords();
            var sortedList = JsonConvert.DeserializeObject(sortedInJsonFormate);
            string first = sortedList[0];
            Assert.AreEqual("Andhra Pradesh", first);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void LastStateNameIn_JSONFormate()
        {
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 0;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var sortedJsonFile = state.getSortedRecords();
            //Deserealize from object to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            string lastState = sortedList[state.getTotalRecords()];
            Assert.AreEqual("West Bengal", lastState);
        }
    }

    public class CsvCodeDataTestThrough_CsvBuilder
    {
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void HeadersIn_CsvCode()
        {
            string[] expectedHeader = { "SrNo", "StateName", "TIN", "StateCode" };
            int jasonForm = 1;
            int sorting = 1;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var output = state.getHeaders();

            for (int i = 0; i < expectedHeader.Length; i++)
            {

                Assert.AreEqual(expectedHeader[i], output[i]);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void FirstStateIn_CSVCode()
        {
            var expectedState = "AD";
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var firstState = state.getTotalRecords();
            firstState = firstState[0];
            Assert.AreEqual(expectedState, firstState);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void LastStateIn_CsvCode()
        {
            var expectedState = "WB";
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var lastRecordNumber = state.getTotalRecords();
            var LastStateName = state.getSortedRecords();
            LastStateName = LastStateName[lastRecordNumber];
            Assert.AreEqual(expectedState, LastStateName);
        }

        [Test]
        public void FirstStateOf_JSONFormat()
        {
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var sortedJsonFile = state.getSortedRecords();
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            string first = sortedList[0];
            Assert.AreEqual("AD", first);

        }

        [Test]
        public void LastStateOf_JSONFormat()
        {
            int jasonForm = 0;
            int sorting = 0;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var sortedJsonFile = state.getSortedRecords();
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            string lastState = sortedList[state.getTotalRecords()];
            Assert.AreEqual("WB", lastState);

        }

        [Test]
        public void TotalRecordsIn_CsvCode()
        {
            int jasonForm = 1;
            int sorting = 1;
            int columnNumber = 3;
            CSVData state = new CSVData(pathStateData, jasonForm, sorting, columnNumber);
            var numberOfRecord = state.getTotalRecords();
            Assert.AreEqual(37, numberOfRecord);
        }
    }
}