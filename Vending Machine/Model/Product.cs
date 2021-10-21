using Lexicon.VendingMachine.Interface;
using Lexicon.VendingMachine.States;

namespace Lexicon.VendingMachine.Model
{
    public abstract class Product
    {
        protected IProductState State;

        protected Product()
        {
            State = new SaleState();
        }

        public abstract string Description { get; }
        public abstract string UsageInformation { get; }

        public abstract double Cost { get; }

        public string Use()
        {
            return "Usage: " + State.Use(this);
        }

        public Product SetState(IProductState state)
        {
            State = state;
            return this;
        }

        public Product Purchase(VendingMachine vendingMachine)
        {
            return State.Purchase(vendingMachine, this);
        }

        public Product ShallowCopy()
        {
            return (Product) MemberwiseClone();
        }
    }
}