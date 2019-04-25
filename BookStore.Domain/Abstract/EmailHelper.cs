using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using System.Web;
 
namespace BookStore.Domain.Abstract
{
   public class SendEmail  :IOrderProcessor
    {
        private MailSettings ESettings = new MailSettings();
        public void ProcessOrderMail(string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            mail.To.Add(ESettings.MailToAdress);
            mail.From = new MailAddress(ESettings.MailFromAdress);
            mail.Subject = "New Order Has Been Submitted";
            mail.IsBodyHtml = true;
            //using (StreamReader reader = File.OpenText( @"E:\00\ASP.NET\MVC5\AS\BookStore\BookStore.WebUI\Views\Cart\EmailTemplete.cshtml "))
            //{  mail.Body = reader.ReadToEnd(); }  
            mail.Body = body;
            SmtpServer.Host = ESettings.ServerName;
            SmtpServer.Port = ESettings.ServerPort;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; 
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                if (ex.InnerException != null)
                Debug.WriteLine("Exception Inner:   " + ex.InnerException);
            }
         }








    }


     class MailSettings 
    { 
        
    public string MailToAdress = "almasry201174@gmail.com,a.mohamed@virtualprojects.build";
    public string MailFromAdress = "a.mohamed@virtualprojects.build";
    public bool UseSSl = true;
    public string UserName = "";
    public string Password = "";
    public string ServerName = "mail.virtualprojects.build";
  // public int ServerPort = 25;
    public int ServerPort = 3535;
    public bool WriteAsFile = false;
    public string Filelocation = @"c:\orders_emails";
    }



        
 













}
