using CensusAnalyzer;
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
                string[] header = read.numberOfHeader(userHeader);
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
    class CSVStateCode
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

        //Test 2
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

        //Test 3
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

        //Test 3
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

        //Test 4
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

        //Test 4
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
}
