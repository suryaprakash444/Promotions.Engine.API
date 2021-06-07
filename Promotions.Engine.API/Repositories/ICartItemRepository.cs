using PromotionsEngine.API.Modules;
using System.Collections.Generic;

namespace PromotionsEngine.API.Repositories
{
    public interface ICartItemRepository
    {
        List<CartItemModel> GetAddToCartItems();
    }
}
