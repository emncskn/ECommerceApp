using CommerceApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.DataAccess
{
    public class CartDal : GenericRepository<Cart, ShopContext>, ICartDal
    {
         void ICartDal.Update(Cart entity)
        {
            using (var context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }

        void ICartDal.DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        Cart ICartDal.GetCart()
        {
            using (var context = new ShopContext())
            {

                return context
                           .Carts
                           .Include(i => i.CartItems)
                           .ThenInclude(i => i.Product)
                           .FirstOrDefault();
            }
        }
    }
}
