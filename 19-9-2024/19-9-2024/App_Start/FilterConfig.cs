﻿using System.Web;
using System.Web.Mvc;

namespace _19_9_2024
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
