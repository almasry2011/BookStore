using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Abstract
{
  public  interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> SpecializationColl();
    }

     

}
