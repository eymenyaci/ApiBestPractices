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
        private IUrlDesignerRepository _urlDesignerRepository;
        
        public PostsController(IPostRepository postRepository, HttpClient client,IUrlDesignerRepository urlDesignerRepository)
        {
            _postRepository = postRepository;
            _client = client;
            _urlDesignerRepository = urlDesignerRepository;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_urlDesignerRepository.getUrl("posts"));
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
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message : {0}", e.Message);
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_postRepository.GetPostById(id) != null)
            {
                await _postRepository.DeletePost(id);
                return Ok();
            }

            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> GetByUserId (int userId)
        {
            if (_postRepository.GetPostByUserId(userId) != null)
            {
                var post = await _postRepository.GetPostByUserId(userId);
                return Ok(post);
            }
            return BadRequest();

        }

    }
}
