using Microsoft.AspNetCore.Mvc;
using SimpleShop.WebAPI.Entities;
using System.Collections.Generic;

namespace SimpleShop.ViewModels.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke (IEnumerable<Product> products)
        {
            return View(products);
        }
    }
}
