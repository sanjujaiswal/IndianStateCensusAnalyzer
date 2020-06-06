using CensusAnalyzer;
using NUnit.Framework;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckNumberOfRecordMatches()
        {
            StateCensusAnalyser read = new StateCensusAnalyser();
            string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
            int record = read.csvFileReadMethod(path, ',');
            Assert.AreEqual(29, record);
        }

        [Test]
        public void CheckFileNotFoundException()
        {
            try
            {
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                int record = read.csvFileReadMethod(path, ',');
            }
            catch (StateCensusException e)
            {
                //If file is not present at the location.
                Assert.AreEqual("file is not present on this location", e.Message);
            }
        }

        [Test]
        public void CheckWrongFileType()
        {
            try
            {
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.txt";
                int record = read.csvFileReadMethod(path, ',');
            }
            catch (StateCensusException e)
            {   // If ypu import wrong file
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }
        [Test]
        public void CheckIncorrectDelimeter()
        {
            try
            {
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                int record = read.csvFileReadMethod(path, ';');
            }
            catch (StateCensusException e)
            {
                //If delimeter is incorrect then throw the exception
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }
        [Test]
        public void CheckIncorrectHeaderNames()
        {
            try
            {
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "AreaInKm", "DensitySqKm" };
                string[] header = read.numberOfHeader(path, enteredHeader);
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
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                string[] enteredHeader = { "State", "Population", "DensityPerSqKm" };
                string[] header = read.numberOfHeader(path, enteredHeader);
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
        public void TotalRecordInIndiaStateCode()
        {
            //object created for stateCensusAnalyser class 
            CSVStateCensus read = new CSVStateCensus();
            string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
            int record = read.csvFileReadMethod(path, ',');
            Assert.AreEqual(37, record);
        }

        [Test]
        public void FileNotFoundForIndiaStateCodeCSVFile()
        {
            try
            {
                CSVStateCensus read = new CSVStateCensus();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                int record = read.csvFileReadMethod(path, ',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File is not present here", e.Message);
            }
        }
      
        [Test]
        public void IncorrectFileOfIndiaStateCode()
        {
            try
            {
                CSVStateCensus read = new CSVStateCensus();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                int record = read.csvFileReadMethod(path, ',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }

        [Test]
        public void IncorrectDelimeterOfIndiaStateCode()
        {
            try
            {
                CSVStateCensus read = new CSVStateCensus();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                int record = read.csvFileReadMethod(path, ';');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect Delimeter, Please enter correct delimeter", e.Message);
            }
        }

        [Test]
        public void IncorrectHeaderNamesOfIndiaStateCode()
        {
            try
            {
                CSVStateCensus read = new CSVStateCensus();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                string[] userHeader = { "SrNo", "State", "Name", "TINNumber", "StateCode", "Column5" };
                string[] header = read.numberOfHeader(path, userHeader);
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
        public void HeaderLengthNotEqualofIndiaStateCode()
        {
            try
            {
                CSVStateCensus read = new CSVStateCensus();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCode.csv";
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                string[] userHeader = { "SrNo", "State", "Name", "TIN"};
                string[] header = read.numberOfHeader(path, userHeader);
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
}