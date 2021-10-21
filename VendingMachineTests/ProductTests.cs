using Lexicon.VendingMachine.Model;
using Lexicon.VendingMachine.Model.Beverage;
using Lexicon.VendingMachine.Model.Snacks;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class ProductTests
    {
        [Fact]
        public void UseUnBoughtProduct()
        {
            const string expected = "Usage: Buy from vending machine";
            Assert.Equal(expected, new CocaCola().Use());
            Assert.Equal(expected, new DoritosNachoCheese().Use());
        }

        [Fact]
        public void UseBoughtProduct()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            vendingMachine.InsertMoney(Denomination.Thousand);

            Assert.Equal("Usage: Drink it", new CocaCola().Purchase(vendingMachine).Use());
            Assert.Equal("Usage: Eat it", new DoritosNachoCheese().Purchase(vendingMachine).Use());
        }

        [Fact]
        public void AddMilkToCoffeeProduct()
        {
            var coffee = new Coffee();
            var expected = coffee.Description + ", Milk";

            var product = new Milk(new Coffee());

            var actual = product.Description;

            Assert.Equal(expected, actual);
            Assert.Equal(coffee.Cost + 1, product.Cost);
        }
    }
}