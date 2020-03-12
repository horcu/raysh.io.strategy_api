namespace raysh.io.strategy_api.Interfaces
{
    public interface IStockToAnalyze
    {
        string Security { get; set; }
        string Range { get; set; }
        string Ts { get; set; }
        string Strategy { get; set; }
    }
}