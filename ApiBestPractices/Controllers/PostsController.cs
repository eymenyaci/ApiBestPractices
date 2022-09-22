using ApiBestPractices.Models;
using ApiBestPractices.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace ApiBestPractices.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        public readonly HttpClient _client = new HttpClient();
        private static List<Post> _posts = new List<Post>();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPosts()
        {
           
        }
    }
}
