﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public interface InterfaceCSVStateCensusAnalyser
    {
        public dynamic ReadData(string Path,int jsonFormate,int sorting, int columnNumber);
    }
}
