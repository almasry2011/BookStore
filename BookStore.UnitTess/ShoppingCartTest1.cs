using System;
using BookStore.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace BookStore.UnitTess
{
    [TestClass]
    public class ShoppingCartTest1
    {        
        //Arrange
        Book b1 = new Book { ISBN = 1, Description = "", Price = 20, Specialization = "", Titel = "" };
        Book b2 = new Book { ISBN = 2, Description = "", Price = 30, Specialization = "", Titel = "" };


        [TestMethod]
        public void Can_AddNew_Book()
        { 
            //Act
            Cart cart = new Cart();
            cart.AddItem(b1);
            cart.AddItem(b2, 2);
            CartLine[] res1 = cart.Lines().ToArray();
           //Assert
            Assert.AreEqual(res1[0].Book, b1);
        }

        [TestMethod]
        public void Can_Calc_CartPrice()
        {
            //Act
            Cart cart = new Cart();
            cart.AddItem(b1);
            cart.AddItem(b2, 2);
            var res = cart.ComputeTotalPrice();
            CartLine[] res1 = cart.Lines().ToArray();

            //Assert
            Assert.AreEqual(res, 80);
        }


        [TestMethod]
        public void Can_Add_QtyForExistingBook()
        {
            //Act
            Cart cart = new Cart();
            cart.AddItem(b1);
            cart.AddItem(b1);
            cart.AddItem(b2);
            cart.AddItem(b1,5);
            CartLine[] res1 = cart.Lines().ToArray();
            //Assert
            Assert.AreEqual(res1[0].Quantity, 7);
            Assert.AreEqual(res1.Length, 2);
        }

        [TestMethod]
        public void Can_remove_Book()
        {
            //Act
            Cart cart = new Cart();
            cart.AddItem(b1);
            cart.AddItem(b2);

            cart.RemoveItem(b1);
            CartLine[] res1 = cart.Lines().ToArray();
            //Assert
           
            Assert.AreEqual(res1.Length,1);
        }

        [TestMethod]
        public void Can_Clear_Cart()
        {
            //Act
            Cart cart = new Cart();
            cart.AddItem(b1);
            cart.AddItem(b2);

            cart.Clear();
            CartLine[] res1 = cart.Lines().ToArray();
            //Assert
            Assert.AreEqual(res1.Length, 0);
        }


    }
}
