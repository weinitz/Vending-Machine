namespace Lexicon.VendingMachine.Exception
{
    public class OutOfStockException : System.Exception
    {
        public OutOfStockException() : base("The product is out of stock")
        {
        }
    }
}