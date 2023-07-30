using CommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.DataAccess
{
    public interface ICartDal :IRepository<Cart>
    {
        Cart GetCart();
        void DeleteFromCart(int cartId, int productId);
        void Update(Cart cart);
    }
}
