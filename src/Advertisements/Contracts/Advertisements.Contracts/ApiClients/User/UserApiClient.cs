﻿using Advertisements.Contracts.Contracts.User;
using Sev1.Advertisements.Domain.Exceptions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sev1.Advertisements.Contracts.ApiClients.User
{
    public sealed partial class UserApiClient : IUserApiClient
    {
        public UserApiClient()
        {
        }

        public async Task<ValidateTokenResponse> ValidateToken(
            string accessToken)
        {
            if(accessToken is null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }

            string param = "";
            string url = "https://localhost:44377/api/v1/accounts/validate-token";
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