using PromotionsEngine.API.Modules;
using System.Collections.Generic;

namespace PromotionsEngine.API.Services
{
    public interface IPromotionService
    {
        decimal EvaluateCartItems(List<CartItemModel> items);
    }
}
