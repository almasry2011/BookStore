using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        IBookRepository Repo;
        IOrderProcessor Repo_Order;
        Cart SHoppingCar = new Cart();
        public CartController(IBookRepository repoParam,IOrderProcessor procParam)
        {
            Repo = repoParam;
            Repo_Order = procParam;
        }
        //GET: Cart
        public RedirectToRouteResult AddToCart(int ISBN, string returnURL)
        {
            var m = Repo.Books.Single(b => b.ISBN == ISBN);
            if (m != null)
            {
                 GetCart().AddItem(m);
            }
            return RedirectToAction("S_CartList", "cart", new { returnURL});
        }


        public RedirectToRouteResult Remove_From_Cart(int ISBN, string returnURL)
        {
            var m = Repo.Books.Single(b => b.ISBN == ISBN);
            if (m != null)
            {
                GetCart().RemoveItem(m);
            }
            return RedirectToAction("S_CartList", "cart", new { returnURL });
        }

        private Cart GetCart()
        {
            Cart cart =(Cart) Session["cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }
            return cart;
        }

        public ActionResult S_CartList(string returnURL)
        {
            CartViewModel m = new CartViewModel
            {
                cart = GetCart(),
                ReturnUrl = returnURL
            };
            return View("AddToCart", m); 
        }


        [HttpPost]
        public ActionResult Checkout( ShippingDetails shippingDetails)
        {  CartViewModel cartModel = new CartViewModel
            {
                   cart = GetCart(),
                   ShippingDetails= shippingDetails
            };
               
            if (cartModel.cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry Your cart Is Empty");
            }
            if (ModelState.IsValid)
                {
              Repo_Order.ProcessOrderMail();
                //cartModel.cart.Clear();
                return View("EmailTemplete", cartModel);
            }
            else
            {
                return View(shippingDetails) ; 
            }

        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails()); 
        }
        public ActionResult EmailTemplete(ShippingDetails shippingDetails)
        {
            CartViewModel cartModel = new CartViewModel
            { cart = GetCart(),
                ShippingDetails = shippingDetails};
                return View("EmailTemplete",cartModel);
        }
        public ActionResult CartSummerty(Cart cart)
        {
            CartViewModel m = new CartViewModel
            {
                cart = GetCart(),
            };

            return PartialView("_CartSummerty", m); 
        }


        //public ActionResult mail(Cart cart)
        //{
        //    SendEmail email = new SendEmail();
        //    email.SendMail("Test","");

        //    return Content("_CartSummerty" );
        //}


    }
}