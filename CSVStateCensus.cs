using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyzer
{
    public class CSVStateCensus : CsvStateCensusReadRecord
    {
        public CSVStateCensus(string Path) : base(Path)
        {

        }
    }
}
    
