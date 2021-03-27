using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimpleShop.ViewModels.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke (IEnumerable<ProductDTO> products)
        {
            return View(products);
        }
    }
}
