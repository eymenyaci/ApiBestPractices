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
        public readonly HttpClient _client = new HttpClient();
        private static List<Post> _posts = new List<Post>();
        public string BaseUrl { get; set; } = "https://jsonplaceholder.typicode.com";
        public string UserUrl { get; set; } = "users";
        public string PhotosUrl { get; set; } = "photos";
        public string AlbumsUrl { get; set; } = "albums";
        public string PostsUrl { get; set; } = "posts";
        public string CommentsUrl { get; set; } = "comments";
        public string TodosUrl { get; set; } = "users";

        public async Task<string> GetResponse()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Post>>(responseBody);

                if (data != null)
                    _posts.AddRange(data);
                return Ok(_posts);


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message : {0}", e.Message);
                return BadRequest();
            }


        }

        private string Ok(List<Post> posts)
        {
            throw new NotImplementedException();
        }

        private string BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}
