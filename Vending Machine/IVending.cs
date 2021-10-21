using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine
{
    public interface IVending
    {
        public Product Purchase(Product product);
        public string ShowAll();
        public void InsertMoney(Denomination sum);
        public double EndTransaction();
    }
}