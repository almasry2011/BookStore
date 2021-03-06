﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookStore.Domain.Concrete;
using BookStore.Domain.Entities;

namespace BookStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private EFDbcontext db = new EFDbcontext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Price,Titel,Description,Specialization,ImgagePath")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Book book,HttpPostedFileBase ImgFile)
        {
            string Bookimage = "";
            try
            {
                if (ImgFile != null)
                {
                    Bookimage = book.ISBN + ".png";
                    string path = Path.Combine(Server.MapPath("~/Bookimages"), Path.GetFileName(Bookimage));
                    ImgFile.SaveAs(path);
                }
                ViewBag.FileStatus = "File uploaded successfully.";
            }
            catch (Exception)
            {
                ViewBag.FileStatus = "Error while file uploading."; ;
            }
            if (ModelState.IsValid)
            {
                var ModBook = db.Books.Find(book.ISBN);
                ModBook.ImgagePath = Bookimage;
                ModBook.Titel = book.Titel;
                ModBook.Specialization = book.Specialization;
                ModBook.Titel = book.Titel;
                ModBook.Price = book.Price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
          
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
