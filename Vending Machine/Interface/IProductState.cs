using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.Interface
{
    public interface IProductState
    {
        public string Use(Product product);
        public Product Purchase(VendingMachine vendingMachine, Product product);
    }
}