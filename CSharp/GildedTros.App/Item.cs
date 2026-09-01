namespace GildedTros.App
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
    public class ExpandedItem
    {
        public Item Item { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsBackstagePass { get; set; }
    }

}
