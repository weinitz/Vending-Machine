using System;
using System.Linq;
using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine
{
    internal class Program
    {
        public static VendingMachine VendingMachine;

        private static void InsertMoney()
        {
            try
            {
                var denominations = Enum.GetValues(typeof(Denomination));
                var joinedDenomination = string.Join(":- ", denominations.Cast<int>());
                var number = GetNumber($"Insert money {joinedDenomination}:- ");
                VendingMachine.InsertMoney(number);
            }
            catch (InvalidDenominationException e)
            {
                WriteOnClearedConsole(e.Message);
                Console.ReadKey(true);
                InsertMoney();
            }
        }

        private static void Main(string[] args)
        {
            VendingMachine = new VendingMachine();
            VendingMachine.Inventory.StockStatusChanged += Inventory_StockStatusChanged;
            InsertMoney();
            do
            {
                PicMenuItem();
                WriteOnClearedConsole("Buy More [enter], or quit [escape]?");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            EndTransaction();
        }

        private static void Inventory_StockStatusChanged(object sender, StockStatusChangedEventArgs e)
        {
            if (e.Flag == StockStatusChangedEventArgs.AllProducts) EndTransaction();
        }

        private static void EndTransaction()
        {
            var change = VendingMachine.EndTransaction();
            WriteOnClearedConsole($"{change}:- refunded. Have a nice day.\nWelcome back");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private static void PicMenuItem()
        {
            var number = GetNumber(VendingMachine.ShowAll(),
                $"Current money pool: {VendingMachine.MoneyPool.Amount}",
                "Insert a menu number: ");

            try
            {
                var product = VendingMachine.Purchase(number);
                WriteOnClearedConsole($"{product.Description}", $"{product.Use()}");
                Console.ReadKey(true);
            }
            catch (System.Exception e)
            {
                WriteOnClearedConsole(e.Message);
                Console.ReadKey(true);
            }
        }

        private static void WriteOnClearedConsole(params string[] formattedText)
        {
            Console.Clear();
            foreach (var text in formattedText) Console.WriteLine(text);
        }

        private static int GetNumber(params string[] description)
        {
            GetInput:
            WriteOnClearedConsole(description);
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var number);
            if (!success) goto GetInput;
            return number;
        }
    }
}