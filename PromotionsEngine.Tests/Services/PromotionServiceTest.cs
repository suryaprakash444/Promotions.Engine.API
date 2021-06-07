using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionsEngine.API.Modules;
using PromotionsEngine.API.Repositories;
using PromotionsEngine.API.Services;
using System.Collections.Generic;
using Xunit;  

namespace PromotionsEngine.Tests.Services
{
    public class PromotionServiceTest
    {
        private readonly Mock<IPromotionRepository> _mockPromoRepository;
        private readonly Mock<ICartItemRepository> _mockCartItemRepository;
        private readonly Mock<ILogger<PromotionService>> _mockLogger;
        private readonly PromotionService _promotionService;

        public PromotionServiceTest()
        {
            _mockPromoRepository = new Mock<IPromotionRepository>();
            _mockCartItemRepository = new Mock<ICartItemRepository>();
            _mockLogger = new Mock<ILogger<PromotionService>>();
            _promotionService = new PromotionService(_mockPromoRepository.Object, _mockLogger.Object);
        }
        [Fact]
        public void EvaluateCartItems_Scenario_A_Return_totalPrice()
        {
            var prmotions = GetPromotionConfiguration();
            var cartItems = CreateCartModel_Scenario_A();
            _mockPromoRepository.Setup(p => p.GetPromotionConfiguration()).Returns(prmotions);

            var totalDiscountPrice = _promotionService.EvaluateCartItems(cartItems);
            Assert.IsNotNull(totalDiscountPrice);
            Assert.Equals(totalDiscountPrice, 100);
        }
        [Fact]
        public void EvaluateCartItems_Scenario_B_Return_totalPrice()
        {
            var prmotions = GetPromotionConfiguration();
            var cartItems = CreateCartModel_Scenario_B();
            _mockPromoRepository.Setup(p => p.GetPromotionConfiguration()).Returns(prmotions);

            var totalDiscountPrice = _promotionService.EvaluateCartItems(cartItems);
            Assert.IsNotNull(totalDiscountPrice);
            Assert.Equals(totalDiscountPrice, 370);
        }
        [Fact]
        public void EvaluateCartItems_Scenario_C_Return_totalPrice()
        {
            var prmotions = GetPromotionConfiguration();
            var cartItems = CreateCartModel_Scenario_C();
            _mockPromoRepository.Setup(p => p.GetPromotionConfiguration()).Returns(prmotions);

            var totalDiscountPrice = _promotionService.EvaluateCartItems(cartItems);
            Assert.IsNotNull(totalDiscountPrice);
            Assert.Equals(totalDiscountPrice, 280);
        }
        private List<PromotionModel> GetPromotionConfiguration()
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
        private static List<CartItemModel> CreateCartModel_Scenario_A()
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            CartItemModel cartItem1 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("B"), new ProductModel("C") });
            cartItems.AddRange(new CartItemModel[] { cartItem1 });

            return cartItems;
        }
        private static List<CartItemModel> CreateCartModel_Scenario_B()
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            CartItemModel cartItem1 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("C") });
            cartItems.AddRange(new CartItemModel[] { cartItem1 });

            return cartItems;
        }
        private static List<CartItemModel> CreateCartModel_Scenario_C()
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            CartItemModel cartItem1 = new CartItemModel(1, new List<ProductModel>() { new ProductModel("A"), new ProductModel("A"), new ProductModel("A"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("B"), new ProductModel("D") });
            cartItems.AddRange(new CartItemModel[] { cartItem1 });

            return cartItems;
        }
    }
}
