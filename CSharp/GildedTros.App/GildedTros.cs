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
            for (var i = 0; i < ExpandedItems.Count; i++)
            {
                if (ExpandedItems[i].Item.Name != "Good Wine" 
                    && ExpandedItems[i].Item.Name != "Backstage passes for Re:factor"
                    && ExpandedItems[i].Item.Name != "Backstage passes for HAXX")
                {
                    if (ExpandedItems[i].Item.Quality > 0)
                    {
                        if (ExpandedItems[i].Item.Name != "B-DAWG Keychain")
                        {
                            ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (ExpandedItems[i].Item.Quality < 50)
                    {
                        ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality + 1;

                        if (ExpandedItems[i].Item.Name == "Backstage passes for Re:factor"
                        || ExpandedItems[i].Item.Name == "Backstage passes for HAXX")
                        {
                            if (ExpandedItems[i].Item.SellIn < 11)
                            {
                                if (ExpandedItems[i].Item.Quality < 50)
                                {
                                    ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality + 1;
                                }
                            }

                            if (ExpandedItems[i].Item.SellIn < 6)
                            {
                                if (ExpandedItems[i].Item.Quality < 50)
                                {
                                    ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (ExpandedItems[i].Item.Name != "B-DAWG Keychain")
                {
                    ExpandedItems[i].Item.SellIn = ExpandedItems[i].Item.SellIn - 1;
                }

                if (ExpandedItems[i].Item.SellIn < 0)
                {
                    if (ExpandedItems[i].Item.Name != "Good Wine")
                    {
                        if (ExpandedItems[i].Item.Name != "Backstage passes for Re:factor"
                            && ExpandedItems[i].Item.Name != "Backstage passes for HAXX")
                        {
                            if (ExpandedItems[i].Item.Quality > 0)
                            {
                                if (ExpandedItems[i].Item.Name != "B-DAWG Keychain")
                                {
                                    ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality - ExpandedItems[i].Item.Quality;
                        }
                    }
                    else
                    {
                        if (ExpandedItems[i].Item.Quality < 50)
                        {
                            ExpandedItems[i].Item.Quality = ExpandedItems[i].Item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
