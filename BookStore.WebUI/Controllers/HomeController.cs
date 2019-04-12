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
        public int PageSize = 2;
        private IBookRepository repo;
        public HomeController(IBookRepository repoParam)
        {
            repo = repoParam;
        }

        public ActionResult ListAll()
        {

            return View(repo.Books);
        }

        public ActionResult List(int page=1)
        {
            //2-per Page
            //(2-1)*2=2
            //(3-1)*2=4
            return View("listall",repo.Books
                .OrderBy(b=>b.ISBN) 
                .Skip((page-1)* PageSize)
                .Take(PageSize)
                );
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