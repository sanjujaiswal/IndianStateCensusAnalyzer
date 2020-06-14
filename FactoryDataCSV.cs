using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
   public class FactoryDataCSV : CSVBuilder
    {
        string path;
        int sort;
        int columnNumber;
        int jsonForm;
        public FactoryDataCSV(string path, int sorting, int columnNumber, int jsonForm)
        {
            this.path = path;
            this.sort = sorting;
            this.columnNumber = columnNumber;
            this.jsonForm = jsonForm;
        }
        public void getHeader()
        {
            var storeData = ReadData(path, jsonForm, sort, columnNumber);
             Console.WriteLine(storeData.Item3);
        }
    }
}
