using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<ExpandedItem> Inventory = new List<ExpandedItem>{
                new NormalItem{Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new AgingWine {Name = "Good Wine", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new LegendaryItem {Name = "B-DAWG Keychain", SellIn = 0, Quality = 80},
                new LegendaryItem {Name = "B-DAWG Keychain", SellIn = -1, Quality = 80},
                new BackstagePass {Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20},
                new BackstagePass {Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 49},
                new BackstagePass {Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49},
                // these smelly items do not work properly yet
                new SmellyItem {Name = "Duplicate Code", SellIn = 3, Quality = 6},
                new SmellyItem {Name = "Long Methods", SellIn = 3, Quality = 6},
                new SmellyItem {Name = "Ugly Variable Names", SellIn = 3, Quality = 6}
            };

            var app = new GildedTros(Inventory);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Inventory.Count; j++)
                {
                    Console.WriteLine(Inventory[j].Name + ", " + Inventory[j].SellIn + ", " + Inventory[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
