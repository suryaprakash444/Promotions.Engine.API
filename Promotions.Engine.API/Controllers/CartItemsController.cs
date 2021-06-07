using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromotionsEngine.API.Modules;
using PromotionsEngine.API.Services;
using System;
using System.Collections.Generic;

namespace PromotionController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly IPromotionService _promoServices;
        private readonly ICartItemService _cartItemServices;
        private readonly ILogger<CartItemsController> _logger;
        public CartItemsController(IPromotionService promoServices, ICartItemService cartItemServices, ILogger<CartItemsController> logger)
        {
            _promoServices = promoServices;
            _cartItemServices = cartItemServices;
            _logger = logger;
        }
        [HttpPost]
        [Route("EvaluateCartItems")]
        public IActionResult EvaluateCartItems(List<CartItemModel> cartItems)
        {
            try
            {
                if (cartItems == null)
                    cartItems = _cartItemServices.GetAddToCartItems();

                var results = _promoServices.EvaluateCartItems(cartItems);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in EvaluateCartItems {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
