using CensusAnalyzer;
using NUnit.Framework;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        //path of file StateCensusData.csv
        static string pathStateData = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
        //create a object of stateCensusAnalyser class 
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
                //If file is not present at the location.
                Assert.AreEqual("File is not present here", e.Message);
            }
        }

        [Test]
        public void CheckWrongFileType()
        {
            try
            {
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.txt";
<<<<<<< HEAD
                int record = read.csvFileReadMethod(path, ',');
=======
                StateCensusAnalyser read = new StateCensusAnalyser(path);
                int record = read.csvFileReadMethod(',');
>>>>>>> Refactor_1
            }
            catch (StateCensusException e)
            {   //Message popup,if extdension of file is wrong.
                Assert.AreEqual("Please enter proper file", e.Message);
            }
        }

        //Test3
        [Test]
        public void CheckIncorrectDelimeter()
        {
            try
            {
<<<<<<< HEAD
                StateCensusAnalyser read = new StateCensusAnalyser();
                string path = @"C:\Users\HP\source\repos\CensusAnalyzer\IndiaStateCensusData.csv";
                int record = read.csvFileReadMethod(path, ';');
=======
                int record = read.csvFileReadMethod(';');
>>>>>>> Refactor_1
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
<<<<<<< HEAD
                string[] enteredHeader = { "State", "Population", "AreaInKm", "DensitySqKm" };
                string[] header = read.numberOfHeader(path, enteredHeader);
=======
                string[] userHeader = { "State", "Population", "AreaInKm", "DensityPerSqKm" };
                string[] header = read.numberOfHeader(userHeader);
>>>>>>> Refactor_1
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
<<<<<<< HEAD
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
=======
                string[] userHeader = { "State", "Population", "DensityPerSqKm" };
                string[] header = read.numberOfHeader(userHeader);
>>>>>>> Refactor_1
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
