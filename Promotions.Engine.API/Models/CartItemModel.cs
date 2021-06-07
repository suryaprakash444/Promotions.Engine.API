using System.Collections.Generic;

namespace PromotionsEngine.API.Modules
{
    public class CartItemModel
    {
        public int OrderId { get; set; }
        public List<ProductModel> Products { get; set; }

        public CartItemModel(int orderId, List<ProductModel> products)
        {
            this.OrderId = orderId;
            this.Products = products;
        }
    }
}
