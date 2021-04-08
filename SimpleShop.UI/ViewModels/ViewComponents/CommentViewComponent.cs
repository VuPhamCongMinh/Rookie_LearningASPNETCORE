using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.UI.ViewModels.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly IHttpClientService httpClientService;

        public CommentViewComponent (IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync (int productId)
        {
            return View(await httpClientService.GetRatingByProductId(productId));
        }

    }
}
