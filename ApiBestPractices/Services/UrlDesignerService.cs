using static System.Net.WebRequestMethods;

namespace ApiBestPractices.Services
{
    public class UrlDesignerService : IUrlDesignerRepository
    {
        /// <summary>
        /// İstek atılacak baseUrl ve PathUrl birleştirir.
        /// </summary>
        /// <param name="PathUrl"></param>
        /// <returns></returns>
        public string getUrl(string PathUrl)
        {
            string BaseUrl = "https://jsonplaceholder.typicode.com";

            BaseUrl = BaseUrl + "/" + PathUrl;

            return BaseUrl;
        }
    }
}
