using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.Data
{
    public class MoneyPool
    {
        public double Amount { get; set; }

        public Product DecreaseByCost(Product product)
        {
            if (Amount < product.Cost) throw new NotEnoughMoneyException();

            Amount -= product.Cost;
            return product;
        }

        public double EndTransaction()
        {
            var amount = Amount;
            Amount = 0;
            return amount;
        }
    }
}