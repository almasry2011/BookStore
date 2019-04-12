using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Concrete
{
  public class EFDbcontext:DbContext
    {
     public DbSet<Book> Books { set; get; }

    }
}
