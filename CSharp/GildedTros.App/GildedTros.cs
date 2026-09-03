using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<ExpandedItem> ExpandedItems;
        public GildedTros(IList<ExpandedItem> ExpandedItems)
        {
            this.ExpandedItems = ExpandedItems;
        }

        public void UpdateQuality()
        {
            foreach (var item in ExpandedItems)
            {
                item.UpdateItem();
            }
        }
    }
}
