using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Entities
{
    //Juction Tablo :ilişkilendirmek istenen iki tablonun primary key alanlarını
    //bağlantı sütünlarıyla (fk) ile ilişkilendirmek için kullanılır. Çoka-çok ilişki
    //kurabişlmek için.

    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } //nav prop

        public Category Category { get; set; } //nav prop
        public int CategoryId { get; set; }
    }
}
