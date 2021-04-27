using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.UI.Constant;
using System.Collections.Generic;
using System.Net.Http;

namespace SimpleShop.ViewModels.ViewComponents
{
    public class MostOrderedProduct : ViewComponent
    {
        private readonly IHttpClientService httpClientService;

        public MostOrderedProduct (IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync ()
        {
            return View(await httpClientService.GetMostOrderedProducts());
        }
    }
}
