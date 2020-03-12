using System;
using System.Collections.Generic;
using System.Text;
using raysh.io.core.enums;
using raysh.io.core.Interfaces;

namespace raysh.io.core.Poco
{
    public class StockToAnalyze : IStockToAnalyze
    {
        public string Security { get; set; }
        public string Range { get; set; }
        public string Ts { get; set; }
        public string Strategy { get; set; }
    }

}
