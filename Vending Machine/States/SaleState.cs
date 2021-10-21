using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.States
{
    public class SaleState : IProductState
    {
        public string Use(Product product)
        {
            return "Buy from vending machine";
        }

        public Product Purchase(VendingMachine vendingMachine, Product product)
        {
            return vendingMachine.Purchase(product);
        }
    }
}