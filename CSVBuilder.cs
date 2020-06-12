using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    class CSVBuilder : InterfaceCSVStateCensusAnalyser
    {
        /// <summary>
        /// Data stored into array like records,headers.
        /// </summary>
        public string[] records;
        public string[] headers;
        public int numberOfRecords;
        public dynamic readData(string Path)
        {
            try
            {
                using StreamReader read = new StreamReader(Path);
                using CsvReader csvreader = new CsvReader(read, true);
                Console.WriteLine(csvreader);
                int fieldCount = csvreader.FieldCount;
                string[] headers = csvreader.GetFieldHeaders();
                //Here, Declared Array list to store the number of records. 
                List<string[]> records = new List<string[]>();
                int numberOfRecords = 0;
                while (csvreader.ReadNextRecord())
                {
                    string[] storeTempRecord = new string[fieldCount];
                    csvreader.CopyCurrentRecordTo(storeTempRecord);
                    records.Add(storeTempRecord);
                    numberOfRecords++;

                    foreach (string[] Record in records)
                    {
                        Console.WriteLine(" ", Record);
                    }
                }

                if (numberOfRecords == 0)
                {
                throw new StateCensusException(StateCensusException.TypeOfExceptions.FILE_CONTAIN_NO_DATA, "This file does not contains any data or records");
                }
                return (records, headers, numberOfRecords);
            }
            catch (StateCensusException e)
            {
                Console.WriteLine(e.Message);
                throw new StateCensusException(StateCensusException.TypeOfExceptions.FILE_CONTAIN_NO_DATA, e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw new FileNotFoundException(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw new IndexOutOfRangeException(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Get records
        /// </summary>
        /// <returns></returns>

        public string[] GetRecord()
        {
            return records;
        }
        public string[] GetHeader()
        {
            return headers;
        }
        public int GetNumberOfRecord()
        {
            return numberOfRecords;
        }
    }
}