using CommerceApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.DataAccess
{
    public static class SeeedData
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);

                    context.AddRange(ProductCategory);

                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories =     {
            new Category() { Name="Ev Giyim"},
            new Category() { Name="Ev Tekstili"},
            new Category() { Name="Ev Aksesuarları"}
        };

        private static Product[] Products =
        {
            new Product(){ Name="Viskon Pijama Alt", Price=200, ImageUrl="1.jpg", Description="<p>kaliteli ürün</p>"},
            new Product(){ Name="Viskon Pijama Üst", Price=300, ImageUrl="2.jpg",Description="<p>kaliteli ürün</p>"},
            new Product(){ Name="Biker Tayt", Price=400, ImageUrl="3.jpg", Description = "<p>kaliteli ürün</p>"},
            new Product(){ Name="Detay Atlet", Price=500, ImageUrl="4.jpg", Description = "<p>kaliteli ürün</p>"},
            new Product(){ Name="Eşofman Takımı-1", Price=600, ImageUrl="5.jpg", Description = "<p>kaliteli ürün</p>"},
            new Product(){ Name="Eşofman Takımı-2", Price=400, ImageUrl="6.jpg", Description = "<p>kaliteli ürün</p>"},
            new Product(){ Name="Eşofman Takımı-3", Price=500, ImageUrl="7.jpg", Description = "<p>kaliteli ürün</p>"}
        };

        private static ProductCategory[] ProductCategory =
       {
            new ProductCategory() { Product= Products[0],Category= Categories[0]},
            new ProductCategory() { Product= Products[0],Category= Categories[2]},
            new ProductCategory() { Product= Products[1],Category= Categories[0]},
            new ProductCategory() { Product= Products[1],Category= Categories[1]},
            new ProductCategory() { Product= Products[2],Category= Categories[0]},
            new ProductCategory() { Product= Products[2],Category= Categories[2]},
            new ProductCategory() { Product= Products[3],Category= Categories[1]}
        };
    }
}

