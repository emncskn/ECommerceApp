using CommerceApp.Business.CategoryManager;
using CommerceApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(), //? koymayınca hata veriyor.araştır
                Categories = _categoryService.GetAll()
            });
        }
    }
}
