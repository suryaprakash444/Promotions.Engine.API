using PromotionsEngine.API.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionsEngine.API.Repositories
{
    public class CartItemRepository: ICartItemRepository
    {
        public List<CartItemModel> GetAddToCartItems()
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            CartItemModel cartItem1 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("B"), new ProductModel("C") });
            CartItemModel cartItem2 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("C") });
            CartItemModel cartItem3 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("D") });
            cartItems.AddRange(new CartItemModel[] { cartItem1, cartItem2, cartItem3 });

            return cartItems;
        }
    }
}
