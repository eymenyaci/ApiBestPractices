using ApiBestPractices.Models;
using ApiBestPractices.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using ApiBestPractices.Services;
using System.Reflection.Metadata.Ecma335;

namespace ApiBestPractices.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        public readonly HttpClient _client = new HttpClient();
        private IPostRepository _postRepository;
        //private static UrlDesigner _urlDesigner;


        public PostsController(IPostRepository postRepository, HttpClient client/*, UrlDesigner urlDesigner*/)
        {
            _postRepository = postRepository;
            _client = client;
            //_urlDesigner = urlDesigner;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //string exampleUrl = _urlDesigner.getUrl("posts");
                HttpResponseMessage response = await _client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Post>>(responseBody);
                foreach (var dataItem in data)
                {
                    Post postItem = new Post()
                    {
                        Id = dataItem.Id,
                        UserId = dataItem.UserId,
                        Body = dataItem.Body,
                        Title = dataItem.Title
                    };
                   await _postRepository.CreatePost(postItem);
                }

                return Ok(data);
                
            }
            catch (Exception e)
            {

                throw e;
            }
            
            



        }
    }
}
