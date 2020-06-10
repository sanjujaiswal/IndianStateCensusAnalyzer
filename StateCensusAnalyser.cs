using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace CensusAnalyzer
{
        public class StateCensusAnalyser : baseStateCensusAnalyser
        {
            public StateCensusAnalyser(string Path) : base(Path)
            { 
            }

        public int csvFileReadMethod()
        {
            throw new NotImplementedException();
        }
    }
  }