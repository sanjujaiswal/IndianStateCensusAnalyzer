using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyzer
{
    public class CSVStateCensus
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="path">given path of csv file</param>
    /// <param name="userdelimeter">checked user's delimeter correct or not</param>
    /// <returns></returns>
        public int csvFileReadMethod(string path, char userdelimeter)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                Console.WriteLine(fileInfo);

                string typeOfFile = fileInfo.Extension;
                Console.WriteLine(typeOfFile);
                string expectedType = ".csv";
                if (typeOfFile != expectedType)
                {
                    throw new StateCensusException(StateCensusException.TypeOfExceptions.INCORRECT_FILE, "Please enter proper file");
                }

                int numberOfRecord = 0;
                //stream reader is used to read the data from csv file
                using StreamReader readCsvData = new StreamReader(path);

                //CsvReader is used to load the data on csvreade
                using CsvReader loadCsvData = new CsvReader(readCsvData, true);

                //Iterate the csv file and ReadNextRecord() is used to read next record if present otherwise break.
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
        //To check number of headers and also check its length, name is proper or not.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">given path of csv file</param>
        /// <param name="fileHeaders">check entered header</param>
        /// <returns></returns>
        public string[] numberOfHeader(string path, string[] enteredHeader)
        {
            try
            {
                //Stream reader is used to read the data from csv file.
                StreamReader read = new StreamReader(path);

                //CsvReader is used to load the data on storeCSV variable.
                CsvReader storeCSV = new CsvReader(read, true);

                //To get headers of csv file.
                string[] storeHeaders = storeCSV.GetFieldHeaders();

                if (enteredHeader.Length != storeHeaders.Length)
                {
                    throw new StateCensusException(StateCensusException.TypeOfExceptions.HEADER_LENGTH_NOT_EQUAL, "Header length is not equal");
                }
                //Iterate header
                for (int i = 0; i < storeHeaders.Length; i++)
                {
                    //If header is match with userHeader then execute otherwise throw exception.
                    if (!enteredHeader[i].Equals(storeHeaders[i]))
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
