using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.UI.Constant
{
    public static class ApiUrl
    {
        public static string PRODUCTS_API_URL = $"{Startup.backEndUrl}/api/products";
        public static string FILTERED_PRODUCTS_API_URL = $"{Startup.backEndUrl}/api/getfilteredproducts";
        public static string NEWLY_ADDED_PRODUCTS_API_URL = $"{Startup.backEndUrl}/api/getnewlyaddproducts";
        public static string MOST_ORDERED_PRODUCTS_API_URL = $"{Startup.backEndUrl}/api/getmostorderedproducts";
        public static string CATEGORIES_API_URL = $"{Startup.backEndUrl}/api/categories";
        public static string ORDERS_API_URL = $"{Startup.backEndUrl}/api/orders";
        public static string GET_ORDER_API_URL = $"{Startup.backEndUrl}/api/getuserorder";
        public static string COUNT_ORDER_API_URL = $"{Startup.backEndUrl}/api/countuserorder";
        public static string RATING_API_URL = $"{Startup.backEndUrl}/api/ratings";
    }
}
