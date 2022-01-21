using MVCCodeFirst.Models;
using MVCCodeFirst.Models.Managers;
using MVCCodeFirst.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            DatabaseContext db = new DatabaseContext();


            HomePageViewModel model = new HomePageViewModel();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();
            
            /*
             * Select * from Kisiler veritabanı
             */

            return View(model);
        }
    }
}