using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class ShippingDetails
    {
        [Required(ErrorMessage ="Please Enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter First Address")]
        [Display(Name ="Addrsss 1")]
        public string Line1 { get; set; }
        [Display(Name = "Addrsss 2")]
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Please Enter The City")]
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
       

    }
}
