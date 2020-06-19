using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using ChoETL;

namespace CensusAnalyzer
{
    public class JSONCensus
    {
        /// <summary>
        /// method to Return first state data from json file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SortCsvFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                       .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);

            //serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveFirstDataOnKey(jsonFilepath, key);
        }

        /// <summary>
        /// Method to return/show the last state data from json file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SortCsvFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                       .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);

            // serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
        }

        /// <summary>
        /// Method to sorting the most populated state.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            //StringBuilder can not inherited, its mutable means
            //we can modify the data
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
        }

        //Method to sorting the least populated state.

        public static string ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveFirstDataOnKey(jsonFilepath, key);
        }

        /// <summary>
        /// Method to sort most populated states.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
        }
    }
}