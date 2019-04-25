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
                    .Take(PageSize),
                SpecializationColl = repo.Books.Select(b => b.Specialization).Distinct()

            };
            ViewBag.listall = "list";

            return View("listall", m);
        }
        public ActionResult List(string specialization, int page = 1)
        {
            //2-per Page
            //(2-1)*2=2
            //(3-1)*2=4
            ViewBag.spec = specialization;
            var x = repo.Books.Where(b => b.Specialization == specialization).Skip((page - 1) * PageSize).Take(PageSize).Count();

            BookListViewModel m = new BookListViewModel
            {
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPages = PageSize, TotalItems = repo.Books.Count() },
                Books = repo.Books.OrderBy(b => b.ISBN)
                .Where(b => b.Specialization == null || b.Specialization == specialization)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                CurrentSpecilization = specialization,

                SearchPagesNumber = x,
                SpecializationColl = repo.Books.Select(b => b.Specialization).Distinct()
            };
            return View("listall", m);
        }
        public PartialViewResult Menu()
        {
            BookListViewModel m = new BookListViewModel
            {
                SpecializationColl = repo.Books.Select(b => b.Specialization).Distinct()
            };
            return PartialView("_CustomNav", m);
        }

        public ActionResult Search(string search, int page = 1)
        {
            var q = repo.Books.Where(b => b.Titel.ToLower().Contains(search.ToLower()) || b.Description.ToLower().Contains(search.ToLower()));
            BookListViewModel m = new BookListViewModel
            {
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPages = PageSize, TotalItems = repo.Books.Count() },
                Books = (q.OrderBy(b => b.ISBN)),
                SpecializationColl = repo.Books.Select(b => b.Specialization).Distinct()
            };
            return PartialView("_booklist", m);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
     }
}