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
            //this is too long, refactoring this
            foreach (var item in ExpandedItems)
            {
                if (item.IsLegendary) {
                    LeaveLegendaryItemAsIs(item);
                    continue;
                }
                if (item.IsBackstagePass) {
                    UpdateBackstagePass(item);
                    continue;
                }
                if (item.IsAgingWine) {
                    UpdateAgingWineItem(item);
                    continue;
                }
                if (item.IsSmelly) {
                    UpdateSmellyItem(item);
                    continue;
                }
                UpdateNormalItem(item);
            }

        }

        public ExpandedItem UpdateNormalItem(ExpandedItem expandedItem)
        {
            TryDecreaseQuality(expandedItem);
            expandedItem.DecreaseSellIn();
            return expandedItem;
        }

        public ExpandedItem UpdateSmellyItem(ExpandedItem expandedItem)
        {
            TryDecreaseQuality(expandedItem);
            TryDecreaseQuality(expandedItem);
            expandedItem.DecreaseSellIn();
            return expandedItem;
        }

        public ExpandedItem UpdateAgingWineItem(ExpandedItem expandedItem)
        {
            TryIncreaseQuality(expandedItem, QualityAdjustments.IncreaseBy1);
            expandedItem.DecreaseSellIn();
            return expandedItem;
        }

        public ExpandedItem UpdateBackstagePass(ExpandedItem backstagePass)
        {
            IncreaseBackStagePassQuality(backstagePass);
            backstagePass.DecreaseSellIn();
            return backstagePass;
        }

        
        public void LeaveLegendaryItemAsIs( ExpandedItem legendaryItem)
        {
            //no need to update legendary items
        }

        private ExpandedItem TryDecreaseQuality(ExpandedItem expandedItem)
        {
            if (expandedItem.SellIn > 0 && expandedItem.Quality > 0) { expandedItem.DecreaseQuality(QualityAdjustments.DecreaseBy1); }
            if (expandedItem.SellIn <= 0 && expandedItem.Quality > 0) { expandedItem.DecreaseQuality(QualityAdjustments.DecreaseBy2); }

            return expandedItem;
        }
        private ExpandedItem TryIncreaseQuality(ExpandedItem expandedItem, QualityAdjustments increase)
        {
            if (expandedItem.Quality < (int)QualityAdjustments.MaxQualityNormalItem) 
            {
                expandedItem.IncreaseQuality(increase); 
            }
           
            return expandedItem;
        }

        private ExpandedItem IncreaseBackStagePassQuality(ExpandedItem backstagePass)
        {
            switch (backstagePass.SellIn)
            {
                case <=0:
                    backstagePass.SetQualityToZero();
                    break;

                case < 6:
                    TryIncreaseQuality(backstagePass, QualityAdjustments.BackStagePassQualityExtraExtraIncrease);
                    break;

                case < 11:
                    TryIncreaseQuality(backstagePass, QualityAdjustments.BackStagePassQualityExtraIncrease);
                    break;

                default:
                    TryIncreaseQuality(backstagePass, QualityAdjustments.BackStagePassQualityIncrease);

                    break;
            }
            return backstagePass;
        }

    }
}
