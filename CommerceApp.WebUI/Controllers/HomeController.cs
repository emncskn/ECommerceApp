using CommerceApp.Business.ProductManager;
using CommerceApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            }) ;




        }
    }
}
