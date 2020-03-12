using System;
using System.Collections.Generic;
using System.Text;
using Alpaca.Markets;
using raysh.io.core.enums;

namespace raysh.io.core.Interfaces
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
