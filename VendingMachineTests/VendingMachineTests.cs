using System;
using Lexicon.VendingMachine.Data;
using Lexicon.VendingMachine.Exception;
using Lexicon.VendingMachine.Model;
using Lexicon.VendingMachine.Model.Beverage;
using Xunit;

namespace Lexicon.VendingMachineTests
{
    public class VendingMachineTests
    {
        [Fact]
        public void BuyProductMoneyPoolAmountDecreases()
        {
            const Denomination insertedMoney = Denomination.Fifty;
            var vendingMachine = new VendingMachine.VendingMachine();

            vendingMachine.InsertMoney(insertedMoney);
            var product = vendingMachine.Purchase(new CocaCola());

            var expected = (double) insertedMoney - product.Cost;
            var actual = vendingMachine.MoneyPool.Amount;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuyProductStockDecreases()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            const Denomination insertedMoney = Denomination.Fifty;
            vendingMachine.InsertMoney(insertedMoney);
            var inventoryItem = vendingMachine.Inventory.FindByProduct(new CocaCola());

            var expected = inventoryItem.Stock - 1;
            vendingMachine.Purchase(inventoryItem);
            var actual = inventoryItem.Stock;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuyProductInvalidIndex()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            const Denomination insertedMoney = Denomination.Fifty;
            vendingMachine.InsertMoney(insertedMoney);
            Assert.Throws<IndexOutOfRangeException>(() => vendingMachine.Purchase(-1));
        }

        [Fact]
        public void BuyProductValidIndex()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            const Denomination insertedMoney = Denomination.Fifty;
            vendingMachine.InsertMoney(insertedMoney);
            var moneyPoolAmount = vendingMachine.MoneyPool.Amount;
            var product = vendingMachine.Purchase(5);
            Assert.Equal(moneyPoolAmount - product.Cost, vendingMachine.MoneyPool.Amount);
        }

        [Fact]
        public void BuyProductOutOfStock()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            const Denomination insertedMoney = Denomination.Thousand;
            vendingMachine.InsertMoney(insertedMoney);
            var inventoryItem = vendingMachine.Inventory.FindByProduct(new Vanilla(new CocaCola()));

            Assert.Throws<OutOfStockException>(() => vendingMachine.Purchase(inventoryItem));
        }

        [Fact]
        public void BuyProductNotEnoughMoney()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            const Denomination insertedMoney = Denomination.One;
            vendingMachine.InsertMoney(insertedMoney);


            Assert.Throws<NotEnoughMoneyException>(() => vendingMachine.Purchase(1));
        }


        [Fact]
        public void BuyAlreadyPurchasedProduct()
        {
            const Denomination insertedMoney = Denomination.Fifty;
            var vendingMachine = new VendingMachine.VendingMachine();

            vendingMachine.InsertMoney(insertedMoney);
            var product = vendingMachine.Purchase(new CocaCola());

            Assert.Throws<AlreadyPurchasedException>(() => product.Purchase(vendingMachine));
        }

        [Fact]
        public void InsertInvalidDenomination()
        {
            const int insertedMoney = 1337;
            var vendingMachine = new VendingMachine.VendingMachine();

            Assert.Throws<InvalidDenominationException>(() => vendingMachine.InsertMoney(insertedMoney));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void InsertValidIntDenomination(int sum)
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            vendingMachine.InsertMoney(sum);
            Assert.Equal(sum, vendingMachine.MoneyPool.Amount);
        }

        [Fact]
        public void InsertMoneyEndTransaction()
        {
            const Denomination insertedMoney = Denomination.Fifty;
            var vendingMachine = new VendingMachine.VendingMachine();

            vendingMachine.InsertMoney(insertedMoney);

            var change = vendingMachine.EndTransaction();
            Assert.Equal((int) insertedMoney, change);
        }

        [Fact]
        public void ShowAllContainsTitlesAndProducts()
        {
            var vendingMachine = new VendingMachine.VendingMachine();
            var renderedMenu = vendingMachine.ShowAll();
            var inventory = new Inventory();

            Assert.Contains("Full Menu", renderedMenu);
            Assert.Contains("Beverage", renderedMenu);
            Assert.Contains("Snacks", renderedMenu);
            Assert.Contains(inventory.Products[0].Product.Description, renderedMenu);
            Assert.Contains(inventory.Products[1].Product.Description, renderedMenu);
            Assert.Contains(inventory.Products[2].Product.Description, renderedMenu);
        }
    }
}