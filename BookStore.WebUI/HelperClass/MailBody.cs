using BookStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookStore.WebUI.HtmlHelper
{
    public class MailBody
    {
        public string Body(CartViewModel m)
        {
            StringBuilder tblbody = new StringBuilder();
            string title = "", quantity = "", price = "";
            string name = m.ShippingDetails.Name;
            string Line1 = m.ShippingDetails.Line1;
            string City = m.ShippingDetails.City;
            string Country = m.ShippingDetails.Country;
            foreach (var item in m.cart.Lines)
            {
                title = item.Book.Titel;
                quantity = item.Quantity.ToString();
                price = (item.Quantity * item.Book.Price).ToString("c");
                tblbody.AppendFormat(@"
                  <tr>
                   <td>{0}</td>
                   <td>{1}</td>
                   <td>{2}</td>
                </tr> ", title, quantity, price);
            }


            string BodyFormat = string.Format(@"  
<html lang=""en"">
    <head>    
        <title>
            
        </title>
    </head>
    <body>
        <table style=""width: 50%;max-width: 60%;     margin: 0 auto;  margin-bottom: 20px; font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font - size: 20px;
            line - height: 1.42857143;
        color: #333;      ""  >
            <thead>
         
                            <td style=""width: 30%;   color: red;      font-size: 20px;     ""> BookTitel</td>
                            <td style=""width: 30%;   color: red;      font-size: 20px;     "">  Quantity</td>
                            <td style=""width: 30%;   color: red;      font-size: 20px;     "">  Book.Price </td>
                        </tr>
            </thead>
            <tbody>
                            {0}
              </tbody>
             <tfoot>
                  <tr>
                       <td colspan=""3"" style=""  color: #001dffb0;    margin: 0 auto;  font-size: 30px;   padding-left: 40px;   font-weight: bold;  ""> shippingDetails </td>
                  </tr>
                  <tr>
                        <td colspan=""3"">
                               <table class=""table table-striped"">
                                     <tr> <td style=""width: 30%;   color: red;      font-size: 20px;     ""> Name </td <td style=""font-size: 20px;width: 30%;padding-left: 20px;""  > {1} </td></tr>
                                     <tr > <td style=""width: 30%;   color: red;      font-size: 20px;     "">  Line1</td>    <td style=""font-size: 20px;width: 30%;padding-left: 20px;""  >{2}</td></tr>
                                      <tr> <td style=""width: 30%;   color: red;      font-size: 20px;     "">  City </td>      <td style=""font-size: 20px;width: 30%;padding-left: 20px;""  >{3} </ td ></tr>
                                       <tr><td style=""width: 30%;   color: red;      font-size: 20px;     ""> Country</td> <td style=""font-size: 20px;width: 30%;padding-left: 20px;""  > {4}</td></tr>
                               </table>
                        </td>        
             </tfoot>
        </table>
    </body>
</html>
", tblbody.ToString(), name, Line1, City, Country);

            return BodyFormat;
        }






    }
}