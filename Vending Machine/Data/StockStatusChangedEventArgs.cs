using System;
using System.Diagnostics.CodeAnalysis;

namespace Lexicon.VendingMachine.Data
{
    [ExcludeFromCodeCoverage]
    public class StockStatusChangedEventArgs : EventArgs
    {
        public StockStatusChangedEventArgs(int flag)
        {
            Flag = flag;
        }

        public static int SingleProduct => 0;
        public static int AllProducts => 1;

        public int Flag { get; }
    }
}