using System.Threading;
using System.Threading.Tasks;

namespace SL2021.Infrastructure.Mail
{
    public class MailServiceMock : IMailService
    {
        public Task Send(string recipient, string subject, string message, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
