﻿using System.Web;
using System.Web.Mvc;

namespace T1809E.WAD.PRACT101_TrangDM2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
