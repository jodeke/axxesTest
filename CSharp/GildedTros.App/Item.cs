namespace GildedTros.App
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
    public class ExpandedItem : Item
    {
        public bool IsAgingWine { get; set; } = false;
        public bool IsLegendary { get; set; } = false;
        public bool IsBackstagePass { get; set; } = false;
        public bool IsSmelly { get; set; } = false;
    }

}
