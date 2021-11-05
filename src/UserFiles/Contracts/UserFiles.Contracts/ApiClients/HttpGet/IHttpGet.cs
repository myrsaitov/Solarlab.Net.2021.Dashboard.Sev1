using Sev1.UserFiles.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserFiles.Contracts.ApiClients.HttpGet
{
    /// <summary>
    /// API-клиент: GET запрос
    /// </summary>
    public interface IHttpGet
    {
        /// <summary>
        /// Get-запрос
        /// </summary>
        /// <param name="Uri">Ссылка</param>
        /// <returns></returns>
        Task<string> HttpGetAsync(string Uri);
    }
}
