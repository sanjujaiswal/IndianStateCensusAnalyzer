using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace CensusAnalyzer
{
    public class CsvStateCensusReadRecord
    {
        // Variables declarations
        string actualPath;
        char delimeter;
        int numberOfRecord;

        // Default Constructor
        public CsvStateCensusReadRecord()
        {
        }

        //Parameterised constructor
        public CsvStateCensusReadRecord(string filePath = null)
        {
            this.actualPath = filePath;
        }

        // Declaration of ReadRecords Method
        public object ReadRecords(string[] passHeader = null, char in_delimeter = ',', string filePath = null)
        {
            try
            {
                if (!filePath.Contains(".csv"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_EXTENSION_OF_FILE, "Invalid Extension of file");
                }
                else if (!filePath.Contains(actualPath))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "Invalid file");
                }

                CsvReader csvRecords = new CsvReader(new StreamReader(filePath), true);
                int fieldCount = csvRecords.FieldCount;
                string[] headers = csvRecords.GetFieldHeaders();
                delimeter = csvRecords.Delimiter;
                // string ArrayList
                List<string[]> record = new List<string[]>();
                while (csvRecords.ReadNextRecord())
                {
                    string[] tempRecord = new string[fieldCount];
                    csvRecords.CopyCurrentRecordTo(tempRecord);
                    record.Add(tempRecord);
                    numberOfRecord++;
                }

                if (numberOfRecord == 0)
                {
                    throw new CSVException(CSVException.ExceptionType.FILE_IS_EMPTY, "This file does not contains any data");
                }
                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, "Incorrect Delimeter");
                }
                else if (!IsHeaderSame(passHeader, headers))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER_ERROR, "Invalid Header");
                }
                return numberOfRecord;
            }
            catch (CensusAnalyserException file_not_found)
            {
                return file_not_found.Message;
            }
            catch (CSVException emptyFileException)
            {
                return emptyFileException.Message;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }// End of ReadRecords

        //method will compare two headers 
        // if same return true , if not return false
        private bool IsHeaderSame(string[] passHeader, string[] headers)
        {
            if (passHeader.Length != headers.Length)
            {
                return false;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                // ToLower() :- Returns a copy of string converted to lowercase
                if (headers[i].ToLower().CompareTo(passHeader[i].ToLower()) != 0)
                {
                    return false;
                }
            }
            return true;
        }//End of isHeadersame

        /// <summary>
        /// Declare Dictionary to store its key and value
        /// into it.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public int CountRecords(string[] records)
        {
            int j = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> maping = new Dictionary<string, string>()
                {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
                };
                map.Add(j, maping);
                j++;
            }
            return map.Count;
        }

        /// <summary>
        /// Sorting json data based on key
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JArray SortingJsonBasedOnKey(string jsonFilePath, string key)
        {
            string jsonFile = File.ReadAllText(jsonFilePath);
            JArray CensusArray = JArray.Parse(jsonFile);
            //bubble sort
            for (int i = 0; i < CensusArray.Count - 1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i - 1; j++)
                {
                    if (CensusArray[j][key].ToString().CompareTo(CensusArray[j + 1][key].ToString()) > 0)
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }

        public static JArray SortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray CensusArray = JArray.Parse(jsonFile);
            //sorting in sorting in ascending order
            for (int i = 0; i < CensusArray.Count - 1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i - 1; j++)
                {
                    if ((int)CensusArray[j][key] > (int)CensusArray[j + 1][key])
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }

        /// <summary>
        /// Method to retrive the first state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string firstValue = jArray[0][key].ToString();
            return firstValue;
        }
        /// <summary>
        /// Method to retrive the last state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string lastValue = jArray[jArray.Count - 1][key].ToString();
            return lastValue;
        }
    }
}