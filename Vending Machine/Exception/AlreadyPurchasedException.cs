namespace Lexicon.VendingMachine.Exception
{
    public class AlreadyPurchasedException : System.Exception
    {
        public AlreadyPurchasedException() : base("You have already purchased this product")
        {
        }
    }
}