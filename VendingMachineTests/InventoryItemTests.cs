using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Model;
using Lexicon.VendingMachine.Model.Snacks;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class InventoryItemTests
    {
        [Fact]
        public void ConstructInventoryItem()
        {
            var inventoryId = InventoryItemSequencer.NextInventoryId() + 1;
            var product = new Snickers();
            var inventoryItem = new InventoryItem(product, 1);
            var dispensedProduct = inventoryItem.Dispense();

            Assert.Equal(0, inventoryItem.Stock);
            Assert.Equal(inventoryId, inventoryItem.Index);
            Assert.Equal(product.Description, inventoryItem.Product.Description);
            Assert.Equal(product.Description, dispensedProduct.Description);
            Assert.Equal("Usage: Eat it", dispensedProduct.Use());
        }
    }
}