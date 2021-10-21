using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Model;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class InventoryTests
    {
        [Fact]
        public void BeverageAndSnacksIsTheSameCountAsProducts()
        {
            var inventory = new Inventory();
            var expected = inventory.Beverage.Count + inventory.Snacks.Count;
            var actual = inventory.Products.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindInventoryItemByProduct()
        {
            var inventory = new Inventory();
            var expected = inventory.Beverage[0];
            var actual = inventory.FindByProduct(expected.Product);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DispensProduct()
        {
            var inventory = new Inventory();
            var expected = inventory.Snacks[0].Product.Description;
            var actual = inventory.Dispense(inventory.Snacks[0]).Description;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnStockStatusChanged()
        {
            var inventory = new Inventory();

            var receivedEvent = Assert.Raises<StockStatusChangedEventArgs>(
                a => inventory.StockStatusChanged += a,
                a => inventory.StockStatusChanged -= a,
                () =>
                {
                    for (var i = 0; i <= inventory.Beverage[0].Stock; i++)
                    {
                        inventory.Dispense(inventory.Beverage[0]);
                    }
                }
            );
        }
    }
}