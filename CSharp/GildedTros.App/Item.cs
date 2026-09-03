namespace GildedTros.App
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
    public abstract class ExpandedItem : Item
    {
        public abstract void UpdateItem();
        protected static ExpandedItem TryIncreaseQuality(ExpandedItem expandedItem, QualityAdjustments increase)
        {
            if (expandedItem.Quality < (int)QualityAdjustments.MaxQualityNormalItem)
            {
                expandedItem.IncreaseQuality(increase);
            }

            return expandedItem;
        }
        protected static ExpandedItem TryDecreaseQuality(ExpandedItem expandedItem)
        {
            if (expandedItem.SellIn > 0 && expandedItem.Quality > 0) { expandedItem.DecreaseQuality(QualityAdjustments.DecreaseBy1); }
            if (expandedItem.SellIn <= 0 && expandedItem.Quality > 0) { expandedItem.DecreaseQuality(QualityAdjustments.DecreaseBy2); }

            return expandedItem;
        }
        protected static ExpandedItem IncreaseBackStagePassQuality(ExpandedItem backstagePass)
        {
            switch (backstagePass.SellIn)
            {
                case <= 0:
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
    public class NormalItem : ExpandedItem
    {
        public override void UpdateItem()
        {
            TryDecreaseQuality(this);
            this.DecreaseSellIn();
        }
    }
    public class AgingWine : ExpandedItem
    {
        public override void UpdateItem()
        {
            TryIncreaseQuality(this, QualityAdjustments.IncreaseBy1);
            this.DecreaseSellIn();
        }
    }
    public class LegendaryItem : ExpandedItem
    {
        public override void UpdateItem()
        {
            //no need to update legendary items
        }
    }
    public class BackstagePass : ExpandedItem
    {
        public override void UpdateItem()
        {
            IncreaseBackStagePassQuality(this);
            this.DecreaseSellIn();
        }
    }
    public class SmellyItem : ExpandedItem
    {
        public override void UpdateItem()
        {
            TryDecreaseQuality(this);
            TryDecreaseQuality(this);
            this.DecreaseSellIn();
        }
    }
}
