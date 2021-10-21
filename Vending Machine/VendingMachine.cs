using System;
using System.Linq;
using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.Interface;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine
{
    public class VendingMachine : IVending
    {
        private readonly InventoryMenu _inventoryMenu;
        public readonly Inventory Inventory;
        public MoneyPool MoneyPool;

        public VendingMachine()
        {
            Inventory = new Inventory();
            Inventory.StockStatusChanged += Inventory_StockStatusChanged;
            _inventoryMenu = new InventoryMenu(Inventory);
            MoneyPool = new MoneyPool();
        }

        public Product Purchase(Product product)
        {
            var inventoryItem = Inventory.FindByProduct(product);
            return Purchase(inventoryItem);
        }

        public string ShowAll()
        {
            return _inventoryMenu.Render();
        }

        public void InsertMoney(Denomination sum)
        {
            MoneyPool.Amount += (int) sum;
        }

        public double EndTransaction()
        {
            return MoneyPool.EndTransaction();
        }

        private void Inventory_StockStatusChanged(object sender, StockStatusChangedEventArgs e)
        {
            _inventoryMenu.Build();
        }

        public void ValidatePurchase(InventoryItem inventoryItem)
        {
            if (inventoryItem.Stock <= 0) throw new OutOfStockException();
            if (MoneyPool.Amount < inventoryItem.Product.Cost) throw new NotEnoughMoneyException();
        }

        public Product Purchase(InventoryItem inventoryItem)
        {
            ValidatePurchase(inventoryItem);
            MoneyPool.DecreaseByCost(inventoryItem.Product);
            return Inventory.Dispense(inventoryItem);
        }

        public Product Purchase(int index)
        {
            if (index < 0 || index > Inventory.Products.Count) throw new IndexOutOfRangeException();
            var inventoryItem = Inventory.Products[index - 1];
            return Purchase(inventoryItem);
        }

        public void InsertMoney(int sum)
        {
            var acceptedDenominations = Enum.GetValues(typeof(Denomination)).Cast<int>();
            if (!acceptedDenominations.Contains(sum)) throw new InvalidDenominationException();
            InsertMoney((Denomination) sum);
        }
    }
}