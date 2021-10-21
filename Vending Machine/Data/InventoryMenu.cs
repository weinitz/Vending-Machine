using System.Collections.Generic;
using Lexicon.VendingMachine.Model;

namespace Lexicon.VendingMachine.Data
{
    public class InventoryMenu
    {
        private readonly Inventory _inventory;
        private Menu _menus;

        public InventoryMenu(Inventory inventory)
        {
            _inventory = inventory;
            Build();
        }

        public InventoryMenu Build()
        {
            _menus = new Menu("Full Menu");
            _menus.Add(BuildMenu("Beverage", _inventory.Beverage));
            _menus.Add(BuildMenu("Snacks", _inventory.Snacks));
            return this;
        }

        private static MenuComponent BuildMenu(string name, List<InventoryItem> inventoryItems)
//        private static Menu BuildMenu(string name, List<InventoryItem> inventoryItems)
        {
            var menu = new Menu(name);
            foreach (var inventoryItem in inventoryItems) menu.Add(new MenuItem(inventoryItem));
            return menu;
        }

        public string Render()
        {
            return _menus.Render();
        }
    }
}