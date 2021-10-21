namespace Lexicon.VendingMachine.Model.Beverage
{
    public class Vanilla : CondimentDecorator
    {
        public Vanilla(Beverage beverage) : base(beverage)
        {
        }

        public override string Description => Beverage.Description + " Vanilla";
        public override double Cost => Beverage.Cost + 3;
    }
}