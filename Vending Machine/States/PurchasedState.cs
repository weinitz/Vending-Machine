using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.States
{
    public class PurchasedState : IProductState
    {
        public string Use(Product product)
        {
            return product.UsageInformation;
        }

        public Product Purchase(VendingMachine vendingMachine, Product product)
        {
            throw new AlreadyPurchasedException();
        }
    }
}