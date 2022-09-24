using ApiBestPractices.Models.Posts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace ApiBestPractices.Models
{
    public class UrlDesigner
    {
        
        public string BaseUrl { get; set; } = "https://jsonplaceholder.typicode.com";
        public string UserUrl { get; set; } = "users";
        public string PhotosUrl { get; set; } = "photos";
        public string AlbumsUrl { get; set; } = "albums";
        public string PostsUrl { get; set; } = "posts";
        public string CommentsUrl { get; set; } = "comments";
        public string TodosUrl { get; set; } = "users";

        /// <summary>
        /// Hangi path'e istek atacağımızı bu metot ile belirliyoruz.
        /// </summary>
        /// <param name="pathItem"></param>
        /// <returns></returns>
        public string getUrl(string pathItem)
        {
            string pathUrl = BaseUrl + "/" + pathItem;
            return pathUrl;
        }
        
    }
}
