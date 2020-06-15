using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CensusAnalyzer
{
    public class CSVBuilder
    {
        string Path;
        int jsonForm;
        int sorting;
        int columnNumber;
        public CSVBuilder(string Path, int jsonForm, int sorting, int columnNumber)
        {
            this.Path = Path;
            this.jsonForm = jsonForm;
            this.sorting = sorting;
            this.columnNumber = columnNumber;
        }
        /// <summary>
        /// If you want to sort records send column number.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="jsonForm"></param>
        /// <param name="sorting"></param>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public dynamic ReadData()
        {
            int numberOfRecords = 0;
            try
            {
                using StreamReader read = new StreamReader(Path);
                using CsvReader csvreader = new CsvReader(read, true);
                int fieldCount = csvreader.FieldCount;
                // Using this, know the headers name.
                string[] headers = csvreader.GetFieldHeaders();

                //Here, Declared Array list to store the number of records. 
                List<string[]> records = new List<string[]>();
                //Used to store the sorted list of data.
                List<string> sortList = new List<string>();

                records.Add(headers);
                char delimeter = csvreader.Delimiter;

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

                if (sorting == 0)
                {
                    sortList = ListSorting(records, columnNumber);
                }

                if (jsonForm == 0)
                {
                    var jsonFormdata = JsonSerializer.Serialize(sortList);
                    //return data dynamically
                    return (records, sortList, numberOfRecords, headers, jsonFormdata);

                }
                return (records, numberOfRecords, headers);

            }
            //For Exceptions handling
            catch (StateCensusException e)
            {
                throw new StateCensusException(StateCensusException.TypeOfExceptions.FILE_CONTAIN_NO_DATA, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new FileNotFoundException(e.Message);
            }
        }
        /// <summary>
        /// sort the list
        /// </summary>
        /// <returns></returns>
        /// 

        public List<string> ListSorting(List<string[]> records, int columnNumber)
        {
            int count = records.Count;
            List<string> listSort = new List<string>();
            for (int i = 0; i < count; i++)
            {
                dynamic sortByColumn = records[i];
                //Sort by column number ex. if given records is like: { "State", "Population", "AreaInSqKm", "DensityPerSqKm" }
                // And we sent column 1 which is state then it will sort the state wise.
                string valueOne = sortByColumn[columnNumber];
                //After that sorted data will be added into List
                listSort.Add(valueOne);
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (listSort[j].CompareTo(listSort[i]) > 0)
                    {
                        string[] temp = new string[1];
                        temp[0] = listSort[i];
                        listSort[i] = listSort[j];
                        listSort[j] = temp[0];
                    }
                }
            }
            foreach (string Record in listSort)
            {
                Console.WriteLine(Record);
            }
            return listSort;
        }
    }
}