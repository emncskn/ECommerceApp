using CommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Business.CartManager
{
    public interface ICartService
    {
        void InitializeCart();
        Cart GetCart();
        void AddToCart( int productId, int quantity);
        void DeleteFromCart( int productId);
    }
}
