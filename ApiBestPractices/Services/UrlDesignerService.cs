using static System.Net.WebRequestMethods;

namespace ApiBestPractices.Services
{
    public class UrlDesignerService : IUrlDesignerRepository
    {
        public string getUrl(string PathUrl)
        {
            string BaseUrl = "https://jsonplaceholder.typicode.com";

            BaseUrl = BaseUrl + "/" + PathUrl;

            return BaseUrl;
        }
    }
}
