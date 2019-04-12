using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;
        public HomeController(IBookRepository repoParam)
        {
            repo = repoParam;
        }

        public ActionResult Index()
        {

            return View(repo.Books);
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