using PromotionsEngine.API.Modules;
using PromotionsEngine.API.Repositories;
using System.Collections.Generic;

namespace PromotionsEngine.API.Services
{
    public class CartItemService: ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public List<CartItemModel> GetAddToCartItems()
        {
           return _cartItemRepository.GetAddToCartItems();
        }
    }
}
