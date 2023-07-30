using CommerceApp.Business.CartManager;
using CommerceApp.WebUI.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
       
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
           
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            if(cart == null)
            {
                _cartService.InitializeCart();
                cart = _cartService.GetCart();
            }
            return View(new CartModel()
            {
                CartId = cart.Id,
                
                CartItems =cart.CartItems!=null ? cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList() : new List<CartItemModel>()
                
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart( productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _cartService.DeleteFromCart( productId);
            return RedirectToAction("Index");
        }
    }
}

