namespace PromotionsEngine.API.Modules
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public decimal RegulerPrice { get; set; }
        public ProductModel(string sku)
        {
            SKU = sku;
        }
    }
}
