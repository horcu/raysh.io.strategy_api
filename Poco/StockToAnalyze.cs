using raysh.io.strategy_api.Interfaces;

namespace raysh.io.strategy_api.Poco
{
    public class StockToAnalyze : IStockToAnalyze
    {
        public string Security { get; set; }
        public string Range { get; set; }
        public string Ts { get; set; }
        public string Strategy { get; set; }
    }

}
