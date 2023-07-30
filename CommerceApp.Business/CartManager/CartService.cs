using CommerceApp.DataAccess;
using CommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Business.CartManager
{
    public class CartService : ICartService
    {
        private ICartDal _cartDal;
        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddToCart( int productId, int quantity)
        {
            var cart = GetCart();
            if (cart != null)
            {

                if(cart.CartItems == null)
                {
                    cart.CartItems = new List<CartItem>();
                }
                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartDal.Update(cart);
            }
        }

        public void DeleteFromCart( int productId)
        {
            var cart = GetCart();
            if (cart != null)
            {
                _cartDal.DeleteFromCart(cart.Id, productId);
            }
        }

        public Cart GetCart()
        {
           
                return _cartDal.GetCart();
            
        }

        public void InitializeCart()
        {
            _cartDal.Create(new Cart() { UserId = "0" });
        }
    }
}
