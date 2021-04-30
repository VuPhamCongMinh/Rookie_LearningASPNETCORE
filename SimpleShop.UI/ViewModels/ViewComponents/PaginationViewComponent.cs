using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Models;
using System.Collections.Generic;

namespace SimpleShop.ViewModels.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke (int pages)
        {
            return View(pages);
        }
    }
}
