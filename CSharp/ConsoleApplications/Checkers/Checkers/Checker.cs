using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    enum CheckerType { Simple, Lady }; //Тип шашки обычная или дамка
    enum CheckerColor { White, Black };
    class Checker
    {
        public CheckerColor Color { get; }
        public CheckerType Type { get; set; } = CheckerType.Simple;
        public Checker(CheckerColor color)
        {
            Color = color;
        }
    }
}
