using BookStore.Domain.Abstract;
using BookStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        public int PageSize = 3;
        private IBookRepository repo;
        public BookController(IBookRepository repoParam)
        {
            repo = repoParam;
        }

        public ActionResult ListAll(int page = 1)
        {
            BookListViewModel m = new BookListViewModel
            {
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPages = PageSize, TotalItems = repo.Books.Count() },
                Books = repo.Books.OrderBy(b => b.ISBN)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),     CurrentSpecilization="5"

            };
            ViewBag.listall = "list";

            return View("listall", m);
        }



            public ActionResult List(string specialization, int page=1)
        {
            //2-per Page
            //(2-1)*2=2
            //(3-1)*2=4

            var x = repo.Books.Where(b => b.Specialization == specialization).Skip((page-1)*PageSize).Take(PageSize) .Count()   ;

            BookListViewModel m = new BookListViewModel
            {
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPages = PageSize, TotalItems = repo.Books.Count() },

                Books = repo.Books.OrderBy(b => b.ISBN)
                .Where(b => b.Specialization == null || b.Specialization == specialization)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                CurrentSpecilization = specialization,

                SearchPagesNumber = x


            };


            return View("listall",m );



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