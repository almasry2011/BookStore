﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    
        public class Book
        {
            [Key]
            public int ISBN { get; set; }
            public decimal Price { get; set; }
            public string Titel { get; set; }
            public string Description { get; set; }
            public string Specialization { get; set; }
            public string ImgagePath { get; set; }


    }


     
}
