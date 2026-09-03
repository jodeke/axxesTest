using System;
using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {

        [Fact]
        public void TestNormalItem()
        {
            IList<ExpandedItem> Items = new List<ExpandedItem> { new NormalItem { Name = "normal", SellIn = 15, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            for (var i = 0; i < 31; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal("normal", Items[0].Name);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-16, Items[0].SellIn);
        }
        [Fact]
        public void TestLegendaryItem()
        {
            IList<ExpandedItem> Items = new List<ExpandedItem> { new LegendaryItem { Name = "legendary", SellIn = 10, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            for (var i = 0; i < 31; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal("legendary", Items[0].Name);
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(10, Items[0].SellIn);
        }
        [Fact]
        public void TestBackStagePass()
        {
            IList<ExpandedItem> Items = new List<ExpandedItem> { new BackstagePass { Name = "stagePass", SellIn = 14, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            for (var i = 0; i < 31; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal("stagePass", Items[0].Name);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-17, Items[0].SellIn);
        }
        [Fact]
        public void TestSmellyItem()
        {
            IList<ExpandedItem> Items = new List<ExpandedItem> { new SmellyItem { Name = "smelly", SellIn = 8, Quality = 12 } };
            GildedTros app = new GildedTros(Items);
            for (var i = 0; i < 31; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal("smelly", Items[0].Name);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-23, Items[0].SellIn);
        }
    }
}