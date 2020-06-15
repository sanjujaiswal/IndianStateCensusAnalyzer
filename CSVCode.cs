using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public class CSVCode : CSVBuilder
    {
        public CSVCode(string path, int jsonForm, int sorting, int columnNumber) : base(path, jsonForm, sorting, columnNumber)
        {

        }
        public dynamic getRecords()
        {
            var output = ReadData();
            return output.Item1;
        }
        public dynamic getSortedRecords()
        {
            var output = ReadData();
            return output.Item4;
        }
        public dynamic getHeaders()
        {
            var output = ReadData();
            return output.Item3;
        }
        public dynamic getJsonFormateRecords()
        {
            var output = ReadData();
            return output.Item5;
        }
        public dynamic getTotalRecords()
        {
            var output = ReadData();
            return output.Item2;
        }
    }
}
