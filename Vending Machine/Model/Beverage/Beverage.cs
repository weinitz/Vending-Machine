namespace Lexicon.VendingMachine.Model.Beverage
{
    public abstract class Beverage : Product
    {
        public override string UsageInformation => "Drink it";
    }
}