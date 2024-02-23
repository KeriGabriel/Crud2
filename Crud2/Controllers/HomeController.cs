using Crud2;
using Crud2.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud2.Controllers
{
    public class HomeController : Controller

    {
        SQLData _data = new SQLData();
        public ActionResult Index()
        {
            var ProductList = _data.GetMasterList();
            return View(ProductList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}