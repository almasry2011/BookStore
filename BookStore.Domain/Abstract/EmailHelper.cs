using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
   public class SendEmail  :IOrderProcessor
    {
        private MailSettings ESettings = new MailSettings();

       
        public void ProcessOrderMail()
        {
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            mail.To.Add(ESettings.MailToAdress);
            mail.From = new MailAddress(ESettings.MailFromAdress); //new MailAddress("mail@domain.com");
            mail.Subject = "New Order Has Been Submitted";
            mail.IsBodyHtml = true;
            using (StreamReader reader = File.OpenText( @"C:\Users\a.mohamed\Desktop\usb_driver\BookStore\BookStore.WebUI\Views\Cart\EmailTemplete.cshtml "))
            {  mail.Body = reader.ReadToEnd(); }                                               
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
    //  public int ServerPort = 587;
    public int ServerPort = 3535;
    public bool WriteAsFile = false;
    public string Filelocation = @"c:\orders_emails";
    }





















}
