using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace PruebaTecnica.WEB.Models
{
    public class Mail : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("daviddevsoftware@gmail.com", "Pa$$w0rd2024")
            };

            return client.SendMailAsync("daviddevsoftware@gmail.com", email, subject, htmlMessage);
        }
       
    }
}
