using Sev1.Advertisements.Application.Interfaces.User;
using Sev1.Advertisements.Domain.Exceptions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Implementations.User
{
    public sealed partial class UserServiceV1 : IUserService
    {
        public UserServiceV1()
        {
        }

        public async Task<string> GetCurrentUserId(
            string accessToken,
            CancellationToken cancellationToken)
        {
            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/currentuserid";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    return Encoding.ASCII.GetString(client.UploadData(url, "POST", Encoding.UTF8.GetBytes(param)));
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации"); // TODO
                }
            }
        }
    }
}