using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace SEP.Framework.AppService.Services
{
    // Implement https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-2.1&tabs=visual-studio#debug

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
