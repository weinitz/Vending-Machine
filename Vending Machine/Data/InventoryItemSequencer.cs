namespace Lexicon.VendingMachine.Data
{
    public class InventoryItemSequencer
    {
        private static int _inventoryId;

        public static int NextInventoryId()
        {
            return ++_inventoryId;
        }

        public static void Reset()
        {
            _inventoryId = 0;
        }
    }
}