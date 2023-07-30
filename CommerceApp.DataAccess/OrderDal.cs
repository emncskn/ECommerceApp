using CommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.DataAccess
{
    public class OrderDal :GenericRepository<Order,ShopContext>, IOrderDal
    {
    }
}
