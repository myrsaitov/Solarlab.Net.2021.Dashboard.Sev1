using Sev1.Advertisements.Contracts.Contracts.User;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sev1.Advertisements.Contracts.Exception;
using Microsoft.Extensions.Configuration;

namespace Sev1.Advertisements.Contracts.ApiClients.User
{
    public sealed partial class UserApiClient : IUserApiClient
    {
        private readonly IConfiguration _configuration;
        public UserApiClient(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ValidateTokenResponse> ValidateToken(
            string accessToken)
        {
            if(accessToken is null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }

            string param = "";

            // Считыватем URL запроса из конфига "appsettings.json"
            string url = _configuration["ValidateTokenUrl"];

            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", accessToken);

                try
                {
                    var data = await client.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(param));
                    var jsonString = Encoding.ASCII.GetString(data);

                    ValidateTokenResponse res = JsonConvert.DeserializeObject<ValidateTokenResponse>(jsonString);
                    return res;
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации: " + ex);
                }
            }
        }
    }
}