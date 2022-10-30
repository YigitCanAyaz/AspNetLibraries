namespace HangFire.Web.Service
{
    public interface IEmailSender
    {
        Task Sender(string userId, string message);
    }
}
