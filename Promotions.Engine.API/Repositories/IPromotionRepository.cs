using PromotionsEngine.API.Modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotionsEngine.API.Repositories
{
    public interface IPromotionRepository
    {
        decimal GetTotalPrice(CartItemModel itemModel, PromotionModel prom);
        List<PromotionModel> GetPromotionConfiguration();
    }
}
