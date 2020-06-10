using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyzer
{
    public class baseStateCensusAnalyser
    {
        string Path
        {
            get; set;
        }
        public baseStateCensusAnalyser(string Path)
        {
            this.Path = Path;
        }
        public int csvFileReadMethod(char userdelimeter)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(Path);
                Console.WriteLine(fileInfo);

                string typeOfFile = fileInfo.Extension;
                Console.WriteLine(typeOfFile);
                string expectedType = ".csv";
                if (typeOfFile != expectedType)
                {
                    throw new StateCensusException(StateCensusException.TypeOfExceptions.INCORRECT_FILE, "Please enter proper file");
                }

                int numberOfRecord = 0;
                using StreamReader readCsvData = new StreamReader(Path);
                using CsvReader loadCsvData = new CsvReader(readCsvData, true);
                while (loadCsvData.ReadNextRecord())
                {
                    numberOfRecord++;
                }
                char csvFileDelimeter = loadCsvData.Delimiter;
                if (!csvFileDelimeter.Equals(userdelimeter))
                {
                    throw new StateCensusException(StateCensusException.TypeOfExceptions.INCORRECT_DELIMETER, "Incorrect Delimeter, Please enter correct delimeter");
                }
                return numberOfRecord;
            }
            catch (FileNotFoundException)
            {
                throw new StateCensusException(StateCensusException.TypeOfExceptions.FILE_NOT_FOUND, "File is not present here");
            }
            catch (StateCensusException e)
            {
                throw new StateCensusException(StateCensusException.TypeOfExceptions.INCORRECT_FILE, e.Message);
            }
        }
        public string[] numberOfHeader(string[] userHeader)
        {
            try
            {
                using StreamReader read = new StreamReader(Path);
                using CsvReader storeCSV = new CsvReader(read, true);
                string[] storeHeaders = storeCSV.GetFieldHeaders();
                if (userHeader.Length != storeHeaders.Length)
                {
                    throw new StateCensusException(StateCensusException.TypeOfExceptions.HEADER_LENGTH_NOT_EQUAL, "Header length is not equal");
                }
                for (int i = 0; i < storeHeaders.Length; i++)
                {
                    if (!userHeader[i].Equals(storeHeaders[i]))
                    {
                        throw new StateCensusException(StateCensusException.TypeOfExceptions.HEADER_NAME_NOT_CORRECT, "Header name is not right");
                    }
                }
                return storeHeaders;
            }
            catch (StateCensusException e)
            {
                throw new StateCensusException(StateCensusException.TypeOfExceptions.HEADER_NAME_NOT_CORRECT, e.Message);
            }
        }
    }
}
