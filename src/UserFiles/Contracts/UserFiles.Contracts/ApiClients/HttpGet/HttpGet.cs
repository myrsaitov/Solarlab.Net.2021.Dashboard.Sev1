﻿using Sev1.UserFiles.Contracts.Exceptions;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserFiles.Contracts.ApiClients.HttpGet
{
    /// <summary>
    /// API-клиент: GET запрос
    /// </summary>
    public sealed partial class HttpGet : IHttpGet
    {
        public HttpGet()
        {
        }

        /// <summary>
        /// Выполняет GET-запрос по ссылке
        /// </summary>
        /// <param name="Uri">Ссылка</param>
        /// <returns></returns>
        public async Task<string> HttpGetAsync(string Uri)
        {
            try
            {
                HttpClient hc = new HttpClient();
                Task<Stream> result = hc.GetStreamAsync(Uri);

                Stream vs = await result;
                StreamReader am = new StreamReader(vs);

                return await am.ReadToEndAsync();
            }
            catch (WebException ex)
            {
                throw new NotFoundException("Not Found! " + ex);
            }
        }
    }
}
