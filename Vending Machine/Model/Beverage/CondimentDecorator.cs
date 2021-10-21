namespace Lexicon.VendingMachine.Model.Beverage
{
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage Beverage;

        protected CondimentDecorator(Beverage beverage)
        {
            Beverage = beverage;
        }
    }
}