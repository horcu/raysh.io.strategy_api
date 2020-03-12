using raysh.io.core.enums;

namespace raysh.io.core.Interfaces
{
    public interface IStockToAnalyze
    {
        string Security { get; set; }
        string Range { get; set; }
        string Ts { get; set; }
        string Strategy { get; set; }
    }
}