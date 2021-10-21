using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.States
{
    public interface IProductState
    {
        public string Use(Product product);
        public Product Purchase(VendingMachine vendingMachine, Product product);
    }
}