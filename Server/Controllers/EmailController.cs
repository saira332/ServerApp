using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace Server.Controllers
{
    public class EmailController : ApiController
    {
        public IHttpActionResult sendmail(EmailClass ec)
        {
            string subject = ec.subject;
            string body = "Your Verification code is " + ec.body + "please dont verify your email to activate your account";
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("steptocharity22@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("steptocharity22@gmail.com", "Step2Charity@22");
            smtp.Send(mm);
            return Ok();
        }
    }
}
