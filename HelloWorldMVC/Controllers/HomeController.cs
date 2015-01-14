using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        private static AdventureWorksEntities e;

        public HomeController()
        {
            e = new AdventureWorksEntities();
        }

        ~HomeController()
        {
            e.Dispose();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
           
            ViewBag.Message = "Your app description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyView()
        {
            
            ViewBag.Message = "";
            return View();
        }

        public ActionResult TestGrid()
        {
            ViewBag.Message = "People List";
            return View();
        }

        public ActionResult Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request));
        }

        private static IEnumerable<Person> GetCustomers()
        {
            var customer = (from cust in e.Person
                        select cust).Take(50);
            return customer.AsEnumerable(); 
        }

    }
}
