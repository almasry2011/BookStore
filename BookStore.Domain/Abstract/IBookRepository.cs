using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.Domain.Entities.MyEntities;

namespace BookStore.Domain.Abstract
{
    interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
    }
}
