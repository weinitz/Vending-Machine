namespace Lexicon.VendingMachine.Exception
{
    public class NotEnoughMoneyException : System.Exception
    {
        public NotEnoughMoneyException() : base("Not enough money")
        {
        }
    }
}