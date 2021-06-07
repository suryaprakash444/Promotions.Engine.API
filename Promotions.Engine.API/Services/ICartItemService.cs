using PromotionsEngine.API.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionsEngine.API.Services
{
    public interface ICartItemService
    {
        List<CartItemModel> GetAddToCartItems();
    }
}
