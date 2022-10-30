using SendGrid.Helpers.Mail;
using SendGrid;

namespace HangFire.Web.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("keylowsoftware@gmail.com", "Example User");
            var subject = "Information about HangFire by YigitCanAyaz";
            var to = new EmailAddress("yigitcanayaz2000@gmail.com", "Example User");
            // var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
