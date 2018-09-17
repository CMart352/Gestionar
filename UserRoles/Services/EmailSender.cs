using System.Net.Mail;
using System.Threading.Tasks;

namespace UserRoles.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            const string senderEmail = "crmxyncro@gmail.com";
            const string smtpClientName = "smtp.gmail.com";
            var mail = new MailMessage {IsBodyHtml = true};
            var smtpServer = new SmtpClient(smtpClientName);
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = message;
            smtpServer.Port = 587;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new System.Net.NetworkCredential(senderEmail, "Ch@mp1994");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);

            return Task.CompletedTask;
        }
    }
}
