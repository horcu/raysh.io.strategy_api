using raysh.io.strategy_api.enums;

namespace raysh.io.strategy_api.Interfaces
{
    public interface ISecurityStrategyObject
    {
         StrategyType StrategyType { get; set; }
         string Symbol { get; set; }
    }
}
