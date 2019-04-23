using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class CartViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public ShippingDetails ShippingDetails  { get; set; }
    }
}