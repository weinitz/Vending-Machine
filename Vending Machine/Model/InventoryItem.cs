using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.States;

namespace Lexicon.VendingMachine.Model
{
    public class InventoryItem
    {
        public InventoryItem(Product product, int stock)
        {
            Index = InventoryItemSequencer.NextInventoryId();
            Product = product;
            Stock = stock;
        }

        public int Index { get; }

        public Product Product { get; }

        public int Stock { get; private set; }

        public Product Dispense()
        {
            if (Stock <= 0) throw new OutOfStockException();
            Stock--;
            return Product.ShallowCopy().SetState(new PurchasedState());
        }
    }
}