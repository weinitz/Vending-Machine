namespace Lexicon.VendingMachine.Model.Beverage
{
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage)
        {
        }

        public override string Description => Beverage.Description + ", Milk";
        public override double Cost => Beverage.Cost + 1;
    }
}