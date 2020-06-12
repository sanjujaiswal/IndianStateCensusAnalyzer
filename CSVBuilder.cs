using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    class CSVBuilder : InterfaceCSVStateCensusAnalyser
    {
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
                return (records, headers, numberOfRecords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }
    }
}