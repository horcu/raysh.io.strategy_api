using System;
using System.Collections.Generic;
using System.Text;
using raysh.io.core.enums;

namespace raysh.io.core.Interfaces
{
    public interface ISecurityStrategyObject
    {
         StrategyType StrategyType { get; set; }
         string Symbol { get; set; }
    }
}
