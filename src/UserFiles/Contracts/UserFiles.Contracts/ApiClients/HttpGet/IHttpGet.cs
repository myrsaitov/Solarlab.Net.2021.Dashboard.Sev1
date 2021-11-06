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
