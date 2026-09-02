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
                new ExpandedItem {Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new ExpandedItem {Name = "Good Wine", SellIn = 2, Quality = 0, IsAgingWine = true},
                new ExpandedItem {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new ExpandedItem {Name = "B-DAWG Keychain", SellIn = 0, Quality = 80, IsLegendary = true},
                new ExpandedItem {Name = "B-DAWG Keychain", SellIn = -1, Quality = 80, IsLegendary = true},
                new ExpandedItem {Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20, IsBackstagePass = true},
                new ExpandedItem {Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 49, IsBackstagePass = true},
                new ExpandedItem {Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49, IsBackstagePass = true},
                // these smelly items do not work properly yet
                new ExpandedItem {Name = "Duplicate Code", SellIn = 3, Quality = 6, IsSmelly = true},
                new ExpandedItem {Name = "Long Methods", SellIn = 3, Quality = 6, IsSmelly = true},
                new ExpandedItem {Name = "Ugly Variable Names", SellIn = 3, Quality = 6, IsSmelly = true}
            };

            var app = new GildedTros(Inventory);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Inventory.Count; j++)
                {
                    System.Console.WriteLine(Inventory[j].Name + ", " + Inventory[j].SellIn + ", " + Inventory[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
