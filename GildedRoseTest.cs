using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void SellInItemIsNotNull()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].SellIn, Is.Not.Null);
        }

        [Test]
        public void QualityIsNotNull()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.Not.Null);
        }

        [Test]
        public void GivenStandardProduct_AndSellInIsGreaterThanZero_QualityAndSellInReduceByOne()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 2} };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(1));
            Assert.That(Items[0].SellIn, Is.EqualTo(1));
        }

        [Test]

        public void GivenStandardProduct_AndSellInIsLessThanZero_QualityAndSellInReduceByOne()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(3));
            Assert.That(Items[0].SellIn, Is.EqualTo(-1));
        }

        [Test]

        public void GivenStandardProduct_AndQualityIsZero_QualityShouldBeZero()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [Test]

        public void GivenProductIsAgedBrie_AndSellByInGreaterThanZero_QualityGoesUpByOne()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 0, SellIn = 2} };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(1));
        }

        [Test]

        public void GivenProductIsAgedBrie_AndSellInIsZero_QualityGoesUpByOne()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 0, SellIn = 1 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(1));
        }

        [Test]

        public void GivenProductIsAgedBrie_AndSellInIsLessThanZero_QualityGoesUpByTwo()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 0, SellIn = -2 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(2));
        }

        [Test]

        public void GivenProductIsAgedBrie_AndQualityIs50_ShouldStillBe50()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 50, SellIn = 2 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(50));
        }

        [Test]
        public void GivenProductIsSulfuras_QualityAndSellInShouldNeverChange()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 4, SellIn = 4 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(4));
            Assert.That(Items[0].SellIn, Is.EqualTo(4));
        }

        [Test]
        public void GivenTicketsHasASellInBy10_QualityGoesUpByTwo()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10} };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(12));
        }

        [Test]
        public void GivenTicketsHasASellInBy5_QualityGoesUpByThree()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void GivenTicketsHasASellInGreaterThan10_QualityGoesUpByOne()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void GivenTicketsHasASellInLessThanZero_QualityIsAlwaysZero()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [TestCase(11, 50, 50)]
        [TestCase(11, 49, 50)]
        [TestCase(10, 49, 50)]
        [TestCase(10, 50, 50)]
        [TestCase(5, 50, 50)]
        [TestCase(5, 48, 50)]
        public void GivenTicket_QualityCannotIncreaseHigherThan50(int sellIn, int quality, int expectedQuality)
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void GivenConjuredItemsHasASellInOfMinus1_QualityIsDecreasedTwiceAsFast()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(6));
        }

        [Test]
        public void GivenConjuredItemsHasASellInOf1_QualityIsDecreasedTwiceAsFast()
        {
            //arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            //act
            app.UpdateQuality();
            //assert
            Assert.That(Items[0].Quality, Is.EqualTo(8));
        }
    }
}
