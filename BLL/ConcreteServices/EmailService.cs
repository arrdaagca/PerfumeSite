using BLL.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class EmailService : IEmailService
    {
        public void SendResetPasswordEmail(string toEmail, int userId)
        {
            string fromEmail = "perffume.ss@gmail.com";
            string password = "pdzy fhvx qjzz wxeo";
            string subject = "Şifre Sıfırlama";
            string body = $"<a href=\"https://localhost:7292/User/ResetPassword?id={userId}\" style=\"color: blue; text-decoration: underline;\">Şifre sıfırlamak için tıklayınız.</a>";

            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                })
                {
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(fromEmail),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(toEmail);

                    smtpClient.Send(mailMessage);
                    Console.WriteLine("E-posta başarıyla gönderildi!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
