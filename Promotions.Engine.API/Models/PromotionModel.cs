using System.Collections.Generic;

namespace PromotionsEngine.API.Modules
{
    public class PromotionModel
    {
        public int PromotionId { get; set; }
        public PromotionType PromoType { get; set; }
        public Dictionary<string, int> PromotionProducts { get; set; }
        public decimal DiscountPrice { get; set; }
        public PromotionModel(int promotionId, PromotionType promoType, decimal discountPrice, Dictionary<string, int> promotionProducts)
        {
            this.PromotionId = promotionId;
            this.PromoType = promoType;
            this.DiscountPrice = discountPrice;
            PromotionProducts = promotionProducts;
        }
       

    }
    public enum PromotionType
    {
        Single,
        Double,
    }
}
