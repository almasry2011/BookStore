using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
   public interface IOrderProcessor
    {
        void ProcessOrderMail(string body);
    }

}
