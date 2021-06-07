using PromotionsEngine.API.Modules;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace PromotionsEngine.API.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ILogger<PromotionRepository> _logger;
        public PromotionRepository(ILogger<PromotionRepository> logger)
        {
            _logger = logger;
        }
        public decimal GetTotalPrice(CartItemModel itemModel, PromotionModel prom)
        {
            decimal totalPrice = 0M;
            try
            {
                var cartPromotionCount = itemModel.Products.GroupBy(p => p.SKU)
                                        .Where(prp => prom.PromotionProducts.Any(pd => prp.Key == pd.Key && prp.Count() >= pd.Value))
                                        .Select(rp => rp.Count()).Sum();

                int productPromotionCount = prom.PromotionProducts.Sum(kvp => kvp.Value);

                while (cartPromotionCount >= productPromotionCount)
                {
                    totalPrice += prom.DiscountPrice;
                    cartPromotionCount -= productPromotionCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in GetTotalPrice : {ex.Message}");
            }
            return totalPrice;
        }
        public List<PromotionModel> GetPromotionConfiguration()
        {
            Dictionary<string, int> item1 = new Dictionary<string, int>
            {
                { "A", 3 }
            };
            Dictionary<string, int> item2 = new Dictionary<string, int>
            {
                { "B", 2 }
            };
            Dictionary<string, int> item3 = new Dictionary<string, int>
            {
                { "C", 1 },
                { "D", 1 }
            };

            return new List<PromotionModel>()
            {
                new PromotionModel(1, PromotionType.Single,130,item1),
                new PromotionModel(2, PromotionType.Single,45,item2),
                new PromotionModel(3, PromotionType.Double,30,item3),
            };
        }
    }
}
