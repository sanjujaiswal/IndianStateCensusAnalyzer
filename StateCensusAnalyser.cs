using LumenWorks.Framework.IO.Csv;
using System;
using System.IO;

namespace CensusAnalyzer
{
    public class StateCensusAnalyser : CsvStateCensusReadRecord
    {
       public StateCensusAnalyser(string Path) : base(Path)
        {

        }
    }
}