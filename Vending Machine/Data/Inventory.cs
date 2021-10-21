using System;
using System.Collections.Generic;
using System.Linq;
using Lexicon.VendingMachine.Model;
using Lexicon.VendingMachine.Model.Beverage;
using Lexicon.VendingMachine.Model.Snacks;

namespace Lexicon.VendingMachine.Data
{
    public class Inventory
    {
        public Inventory()
        {
            Beverage = new List<InventoryItem>
            {
                new InventoryItem(new CocaCola(), 2),
                new InventoryItem(new Vanilla(new CocaCola()), 0),
                new InventoryItem(new Coffee(), 12),
                new InventoryItem(new Milk(new Coffee()), 2)
            };

            Snacks = new List<InventoryItem>
            {
                new InventoryItem(new Snickers(), 5),
                new InventoryItem(new DoritosNachoCheese(), 2)
            };
        }

        public List<InventoryItem> Products => Beverage.Union(Snacks).ToList();
        public List<InventoryItem> Beverage { get; }
        public List<InventoryItem> Snacks { get; }
        public event EventHandler<StockStatusChangedEventArgs> StockStatusChanged;

        protected virtual void OnStockStatusChanged()
        {
            var flag = Products.All(x => x.Stock == 0)
                ? StockStatusChangedEventArgs.AllProducts
                : StockStatusChangedEventArgs.SingleProduct;

            var handler = StockStatusChanged;
            handler?.Invoke(this, new StockStatusChangedEventArgs(flag));
        }

        public InventoryItem FindByProduct(Product product)
        {
            return Products.First(x => x.Product.Description == product.Description);
        }

        public Product Dispense(InventoryItem inventoryItem)
        {
            var product = inventoryItem.Dispense();
            if (inventoryItem.Stock <= 0) OnStockStatusChanged();
            return product;
        }
    }
}