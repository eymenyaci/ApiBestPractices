using ApiBestPractices.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ApiBestPractices.Services
{
    public class UrlDesignerService : IUrlDesignerRepository
    {
        public readonly HttpClient _client = new HttpClient();
       
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
