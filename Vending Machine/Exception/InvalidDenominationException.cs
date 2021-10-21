namespace Lexicon.VendingMachine.Exception
{
    public class InvalidDenominationException : System.Exception
    {
        public InvalidDenominationException() : base("Invalid denomination")
        {
        }
    }
}