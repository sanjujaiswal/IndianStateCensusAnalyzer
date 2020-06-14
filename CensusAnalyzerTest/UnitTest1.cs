using CensusAnalyzer;
using NUnit.Framework;
using Newtonsoft.Json;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        static string pathIndiaStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        StateCensusAnalyser readRecord = new StateCensusAnalyser(pathIndiaStateData);

        [SetUp]
        public void Setup()
        {
        }

        /// Test 1
        [Test]
        public void CheckNumberOfRecordMatches()
        {
            int record = readRecord.csvFileReadMethod(',');
            Assert.AreEqual(29, record);
        }

        //Test 2
        [Test]
        public void CheckFileNotFoundException()
        {
            try
            {
                //string path = @"C:\Users\HP\source\repos\CabServices\IndiaStateCensusData.csv";
                int record = readRecord.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File is not present here", e.Message);
            }
        }

        [Test]
        public void CheckIncorrectFileType()
        {
            try
            {
                //string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.txt";
                int record = readRecord.csvFileReadMethod(',');
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
                int record = readRecord.csvFileReadMethod(';');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }

        [Test]
        public void CheckIncorrectHeaderNames()
        {
            try
            {
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "AreaKm", "DensityKm" };
                string[] header = readRecord.numberOfHeader(enteredHeader);
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

        [Test]
        public void IncorrectHeaderLength()
        {
            try
            {
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "DensityPerSqKm" };
                string[] header = readRecord.numberOfHeader(enteredHeader);
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

        [Test]
        public void HeaderNameIsSameOrNot()
        {
            try
            {
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] header = readRecord.numberOfHeader(enteredHeader);
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
    }

    public class CSVStateCode
    {
        static string pathIndiaStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        StateCensusAnalyser readRecord = new StateCensusAnalyser(pathIndiaStateData);
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
        CSVStateCensus readCSVStateCode = new CSVStateCensus(pathStateData);

        [SetUp]
        public void SetUp()
        {
        }
        // Test 1
        [Test]
        public void TotalRecordIn_CSVStateCode()
        {
            int record = readCSVStateCode.csvFileReadMethod(',');
            Assert.AreEqual(37, record);
        }

        /// <summary>
        /// If file is not present on that location then it will show file not found.
        /// </summary>
        [Test]
        public void CSVStateCode_FileNotFoundException()
        {
            try
            {
                string Path = @"C:\Users\HP\source\repos\CensusAnalyzer\StateCode.csv";
                CSVStateCensus readCSVStateCode = new CSVStateCensus(Path);
                int record = readCSVStateCode.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File is not present here", e.Message);
            }
        }

        /// <summary>
        /// If you import wrong file type
        /// It will show Please enter proper file type
        /// </summary>
        [Test]
        public void WrongFileTypeOf_CSVStateCode()
        {
            try
            {
                string Path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.pdf";
                CSVStateCensus readCSVStateCode = new CSVStateCensus(Path);
                int record = readCSVStateCode.csvFileReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }

        /// <summary>
        /// It user enter wrong delimeter.
        /// It will show Please enter correct delimeter.
        /// </summary>
        [Test]
        public void WrongDelimeterOf_CSVStateCode()
        {
            try
            {
                int record = readCSVStateCode.csvFileReadMethod('.');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void WrongHeaderOf_CSVStateCode()
        {
            try
            {
                string[] expectedHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] userHeader = { "SrNo", "State", "TIN", "State" };
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

        [Test]
        public void CheckHeaderNameIsSame_CSVStateCode()
        {
                string[] expectedHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] userHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] header = readCSVStateCode.numberOfHeader(userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], userHeader[i]);
                }
        }

        //Test 4
        [Test]
        public void WrongHeaderLengthOfCSVStateCode()
        {
            try
            {
                string[] expectedHeader = { "SrNo", "State Name", "TIN", "StateCode" };
                string[] userHeader = { "SrNo", "State Name" };
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

    public class CSVBuilderTests
    {
        static string pathIndiaStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        CSVBuilder csvBuilder = new CSVBuilder();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TotalRecordsIn_CSVBuilder()
        {
           // var expectedState = "West Bengal";
            int jsonForm = 1;
            int sorting = 1;
            //Sorting will done on column number 0.
            int columnNumber = 0;
            var result = csvBuilder.ReadData(pathIndiaStateData, jsonForm, sorting, columnNumber);
            //result is stored into firstStateSorted variable which is first sorted record.
            var totalRecords = result.Item2;
            var lastStateName = result.Item2;
            {
                Assert.AreEqual(29, totalRecords);
            }
        }

        [Test]
        public  void ToCheckHeaderOf_CSVBuilder()
        {
            string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            int jsonForm = 1;
            int sorting = 1;
            int columnNumber = 0;

            //ReadData will called and return the result dynamically and 
            //Its result is store into var return tuple.
            //multiple value can return usnig this method.
            var result = csvBuilder.ReadData(pathIndiaStateData, jsonForm, sorting, columnNumber);
            for (int i = 0; i < expectedHeader.Length; i++)
            {
                Assert.AreEqual(expectedHeader[i], result.Item3[i]);
            }
        }

        [Test]
        public void FirstSortedStateIn_CSVBuilder()
        {
            var expectedState = "Andhra Pradesh";
            int jsonForm = 0;
            int sorting = 0;
            //Sorting will done on column number 0.
            int columnNumber = 0;
            var result = csvBuilder.ReadData(pathIndiaStateData, jsonForm, sorting, columnNumber);
            //result is stored into firstStateSorted variable which is first sorted record.
            var firstStateSorted = result.Item2[0];
            {
                Assert.AreEqual(expectedState, firstStateSorted);
            }
        }
        /*
        [Test]
        public void SecondSortedStateIn_CSVBuilder()
        {
            var expectedState = "Arunachal";
            int jsonForm = 0;
            int sorting = 0;
            //Sorting will done on column number 0.
            int columnNumber = 0;
            var result = csvBuilder.ReadData(pathIndiaStateData, jsonForm, sorting, columnNumber);
            //result is stored into firstStateSorted variable which is first sorted record.
            var secondStateSorted = result.Item2[0];
            {
                Assert.AreEqual(expectedState, secondStateSorted);
            }
        }
        */
        [Test]
        public void LastSortedStateIn_CSVBuilder()
        {
            var expectedStateName = "West Bengal";
            int jsonForm = 0;
            int sorting = 0;
            //Sorting will done on column number 0.
            int columnNumber = 0;
            var result = csvBuilder.ReadData(pathIndiaStateData, jsonForm, sorting, columnNumber);
            //result is stored into firstStateSorted variable which is first sorted record.
            var lastStateSorted = result.Item3[0];
            var lastStateName = result.Item2;
            {
                Assert.AreEqual(expectedStateName, lastStateName[lastStateSorted]);
            }
        }
    }
}
