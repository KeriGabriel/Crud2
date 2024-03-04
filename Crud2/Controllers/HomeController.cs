using Crud2;
using Crud2.Data;
using Crud2.Models;
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
        public ActionResult Add() 
        {
            return View();
        }
        public ActionResult About(Product product, Customer customer, Order order)
        {
           _data.AddToOrder(product, order, customer);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}