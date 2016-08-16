using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace HangFireDemo.Controllers
{
    public class HangFireController : ApiController
    {
        #region "HangFire Test"
        [ActionName("HangTest")]
        [HttpPost]
        public HttpResponseMessage HangTest() // This is Post Method , you can check this Method with Google Chrome Extension - PostMan Rest client/Advance Rest Client
        {
            string hangTest = "Success";

            BackgroundJob.Enqueue(() => SendEmail()); // this will enqueue the process in HangFire
            //BackgroundJob.Schedule(() => SendEmail(),TimeSpan.FromDays(1)); // This is method will be used when you want to Schedule the process
            return Request.CreateResponse(HttpStatusCode.OK, hangTest);
        }

        public Boolean SendEmail()
        {
            bool Success = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("<to_email_address>");
                mail.From = new MailAddress("<From Email Address>");// From Email address which you want to use for Sending Email
                mail.Subject = "This is a Test Mail"; // subject for the mail
                string Body = "This Email is for learning HangFire basics."; 
                mail.Body = Body; // Email body

                mail.IsBodyHtml = true; // true/false depending on Email body has html content or not
                SmtpClient smtp = new SmtpClient("<smtp host>", 25); //smtp host, default port is 25
                // smtp.Port = 25;

                //  smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("<From Email Address>", "<Password>"); // From Email address & Password which you want to use for Sending Email
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true; // true/false depending if you want SSL true or false;
                smtp.Send(mail);

                Success = true;
            }
            catch (Exception e)
            {
                Success = false;
                throw new Exception(e.Message);
            }
            return Success;
        }
        #endregion
    }
}
