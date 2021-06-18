using System.Threading.Tasks;

namespace Destiny.Core.Flow.OpenIddictServer.Services
{
  public interface ISmsSender
  {
    Task SendSmsAsync(string number, string message);
  }
}
