using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class Cart
    {
        private List<CartLine> CartList = new List<CartLine>();
              public void AddItem(Book book,int quantity=1)
              {
                var line = CartList.Where(b => b.Book.ISBN == book.ISBN)
                                            .FirstOrDefault();
                        if (line==null)
                        {
                            CartList.Add(new CartLine { Book=book,Quantity=quantity});
                        }
                    else
                        {
                        line.Quantity += quantity;
                        }
               }

              public void RemoveItem(Book book)
              { CartList.RemoveAll(b => b.Book.ISBN == book.ISBN);    }

               public decimal ComputeTotalPrice()
                {
                    return CartList.Sum(p => p.Book.Price * p.Quantity);
                }

               public void Clear()
                {
                    CartList.Clear();
                }

                public IEnumerable<CartLine> Lines ()
                {
                    return CartList.ToList();
                }


    }

        public class CartLine
        {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        }

}
