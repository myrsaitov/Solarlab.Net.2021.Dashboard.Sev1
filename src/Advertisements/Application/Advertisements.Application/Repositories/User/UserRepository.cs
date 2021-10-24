using Sev1.Advertisements.Domain.Exceptions;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Repositories.User
{
    public sealed partial class UserRepository : IUserRepository
    {
        public UserRepository()
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
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    return Encoding.ASCII.GetString(data);
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации: " + ex);
                }
            }
        }

        public async Task<bool> IsAdmin(
            string accessToken,
            CancellationToken cancellationToken)
        {
            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/isadmin";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    var response = Encoding.ASCII.GetString(data);
                    if(response == "true")
                    {
                        return true;
                    }

                    return false;
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации: " + ex);
                }
            }
        }
    }
}