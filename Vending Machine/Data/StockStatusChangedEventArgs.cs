using System;
using System.Diagnostics.CodeAnalysis;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.Data
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