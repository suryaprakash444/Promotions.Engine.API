using Microsoft.Extensions.Logging;
using PromotionsEngine.API.Modules;
using PromotionsEngine.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionsEngine.API.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ILogger<PromotionService> _logger;
        public PromotionService(IPromotionRepository promotionRepository, ILogger<PromotionService> logger)
        {
            _promotionRepository = promotionRepository;
            _logger = logger;
        }
        public decimal EvaluateCartItems(List<CartItemModel> items)
        {
            decimal totalPromotionPrice = 0M;
            try
            {
                var promotions = _promotionRepository.GetPromotionConfiguration();
                foreach (var item in items)
                {
                   var promoprices = promotions
                        .Select(promo => _promotionRepository.GetTotalPrice(item, promo)).ToList();

                    totalPromotionPrice = promoprices.Sum();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in EvaluateCartItemsAsync error message {ex.Message}");
            }
            return totalPromotionPrice;
        }
    }
}
