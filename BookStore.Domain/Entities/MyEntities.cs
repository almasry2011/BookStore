
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    class MyEntities
    {
    
        public class Book
        {
            public int ISBN { get; set; }
            public decimal Price { get; set; }
            public string Titel { get; set; }
            public string Description { get; set; }
            public string Specialization { get; set; }
            public string Author { get; set; }

        }


    }
}
