using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Xunit;
using PromotionsEngine.API.Services;
using Microsoft.Extensions.Logging;
using PromotionController.Controllers;
using PromotionsEngine.API.Modules;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PromotionsEngine.Tests
{
    public class CartItemsControllerTest
    {
        private readonly Mock<IPromotionService> _mockPromoService;
        private readonly Mock<ICartItemService> _mockCartItemService;
        private readonly Mock<ILogger<CartItemsController>> _mockLogger;
        private readonly CartItemsController _cartController;
        public CartItemsControllerTest()
        {
            _mockPromoService = new Mock<IPromotionService>();
            _mockCartItemService = new Mock<ICartItemService>();
            _mockLogger = new Mock<ILogger<CartItemsController>>();
            _cartController = new CartItemsController(_mockPromoService.Object, _mockCartItemService.Object, _mockLogger.Object);
        }

        [Fact]
        public void EvaluateCartItems_Return_OkResponse()
        {
            decimal totalPrice = 100;
            var cartItems = CreateCartModel();
            _mockCartItemService.Setup(p => p.GetAddToCartItems()).Returns(cartItems);
            _mockPromoService.Setup(p => p.EvaluateCartItems(cartItems)).Returns(totalPrice);
            var result = _cartController.EvaluateCartItems(cartItems);
            var objectResult = result as ObjectResult;

            Assert.IsNotNull(objectResult);
            Assert.Equals(objectResult.StatusCode, StatusCodes.Status200OK);
        }
        [Fact]
        public void EvaluateCartItems_Return_InternalServerError()
        {
            List<CartItemModel> cartItems = null;
            _mockPromoService.Setup(p => p.EvaluateCartItems(cartItems)).Throws(new Exception());
            var result = _cartController.EvaluateCartItems(cartItems);
            var objectResult = result as ObjectResult;

            Assert.IsNotNull(objectResult);
            Assert.Equals(objectResult.StatusCode, StatusCodes.Status500InternalServerError);
        }

        public static List<CartItemModel> CreateCartModel()
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
