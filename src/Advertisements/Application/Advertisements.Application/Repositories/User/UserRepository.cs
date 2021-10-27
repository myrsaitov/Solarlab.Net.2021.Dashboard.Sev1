using Advertisements.Contracts;
using Sev1.Advertisements.Domain.Exceptions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sev1.Advertisements.Application.Repositories.User
{
    public sealed partial class UserRepository : IUserRepository
    {
        public object Newtonsoft { get; private set; }

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

        public async Task<GetAutorizedStatusResponse> GetAutorizedStatus(
            string accessToken,
            CancellationToken cancellationToken)
        {
            if(accessToken is null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }

            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/getautorizedstatus";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    var jsonString = Encoding.ASCII.GetString(data);

                    GetAutorizedStatusResponse res = JsonConvert.DeserializeObject<GetAutorizedStatusResponse>(jsonString);

                    return res;
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
        public async Task<bool> IsModerator(
            string accessToken,
            CancellationToken cancellationToken)
        {
            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/ismoderator";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    var response = Encoding.ASCII.GetString(data);
                    if (response == "true")
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

        public async Task<string> GetCurrentUserRole(
            string accessToken,
            CancellationToken cancellationToken)
        {
            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/getcurrentuserrole";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    return Encoding.ASCII.GetString(data).ToLower();
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации: " + ex);
                }
            }
        }
    }
}