using System;
using System.Diagnostics.CodeAnalysis;

namespace Lexicon.VendingMachine.Model
{
    [ExcludeFromCodeCoverage]
    public class StockStatusChangedEventArgs : EventArgs
    {
        public StockStatusChangedEventArgs(StockStatusFlag flag)
        {
            Flag = flag;
        }

        public StockStatusFlag Flag { get; }
    }
}