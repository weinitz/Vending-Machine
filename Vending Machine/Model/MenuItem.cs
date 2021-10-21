using Lexicon.VendingMachine.Data;

namespace Lexicon.VendingMachine.Model
{
    public class MenuItem : MenuComponent
    {
        public MenuItem(InventoryItem inventoryItem)
        {
            Description = inventoryItem.Product.Description;
            Price = inventoryItem.Product.Cost;
            Index = inventoryItem.Index;
            InStock = inventoryItem.Stock > 0;
        }

        public override string Description { get; }

        public override double Price { get; }
        public int Index { get; }
        public bool InStock { get; }

        public override string Render()
        {
            return $"{Index}: {Description} : {Price}:-" + (InStock ? "" : " (Out of stock)");
        }
    }
}