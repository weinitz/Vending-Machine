using Lexicon.VendingMachine.Data;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class InventoryMenuTests
    {
        [Fact]
        public void RenderedInventoryMenuContainsTitles()
        {
            var inventory = new Inventory();
            var inventoryMenu = new InventoryMenu(inventory);
            var rendered = inventoryMenu.Render();

            Assert.Contains("Full Menu", rendered);
            Assert.Contains("Beverage", rendered);
            Assert.Contains("Snacks", rendered);
        }

        [Fact]
        public void RenderedInventoryMenuContainsProductsDescriptions()
        {
            var inventory = new Inventory();
            var inventoryMenu = new InventoryMenu(inventory);
            var rendered = inventoryMenu.Render();

            Assert.Contains(inventory.Products[0].Product.Description, rendered);
            Assert.Contains(inventory.Products[1].Product.Description, rendered);
            Assert.Contains(inventory.Products[2].Product.Description, rendered);
        }
    }
}