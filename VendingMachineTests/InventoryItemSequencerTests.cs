using Lexicon.VendingMachine.Data;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class InventoryItemSequencerTests
    {
        [Fact]
        public void BuyProductMoneyPoolAmountDecreases()
        {
            InventoryItemSequencer.Reset();
            const int expected = 1;
            var actual = InventoryItemSequencer.NextInventoryId();
            Assert.Equal(expected, actual);
        }
    }
}