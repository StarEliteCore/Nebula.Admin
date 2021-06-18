using System.Threading.Tasks;

namespace Destiny.Core.Flow.OpenIddictServer.Services
{
  public interface IEmailSender
  {
    Task SendEmailAsync(string email, string subject, string message);
  }
}
