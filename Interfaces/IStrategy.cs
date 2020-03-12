using System;
using Alpaca.Markets;
using raysh.io.strategy_api.enums;

namespace raysh.io.strategy_api.Interfaces
{
    public interface IStrategy
    {
         string Name { get; set; }
         StrategyPriority StrategyPriority { get; set; }

         string Run(string symbol);
         void AwaitMarketOpen();
         void SubmitOrder(int quantity, Decimal price, OrderSide side);
         void ClosePositionAtMarket();
    }
}
