using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Concrete
{

   public class EFBookRepository : IBookRepository
    {
        EFDbcontext db = new EFDbcontext();
        public IEnumerable<Book> Books => db.Books.ToList();


       

        public IEnumerable<Book> SpecializationColl()
        {
           var x = db.Books.Select(b => b.Specialization).Distinct();
            return (IEnumerable<Book>) x;
        }
    }
}
