using CommerceApp.Business.CartManager;
using CommerceApp.Business.CategoryManager;
using CommerceApp.Business.ProductManager;
using CommerceApp.DataAccess;
using CommerceApp.WebUI.Middleware;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductDal,ProductDal>();
builder.Services.AddScoped<ICategoryDal,CategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICartDal,CartDal>();
builder.Services.AddScoped<ICartService,CartService>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    SeeedData.Seed();
}

SeeedData.Seed();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "adminProducts",
        template: "admin/products",
        defaults: new { controller = "Admin", action = "ProductList" }
      );

    routes.MapRoute(
        name: "adminProduct",
        template: "admin/products/{id?}",
        defaults: new { controller = "Admin", action = "EditProduct" }
    );

    routes.MapRoute(
              name: "cart",
              template: "cart",
              defaults: new { controller = "Cart", action = "Index" }
          );

    routes.MapRoute(
      name: "products",
      template: "products/{category?}",
      defaults: new { controller = "Shop", action = "List" }
    );

    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}"
    );

});

app.UseStaticFiles();

app.CustomStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
