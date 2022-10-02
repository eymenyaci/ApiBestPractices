using ApiBestPractices.Models.Posts;
using ApiBestPractices.Models.Users;
using ApiBestPractices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiBestPractices.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public readonly HttpClient _client = new HttpClient();
        private IUrlDesignerRepository _urlDesignerRepository;
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository, HttpClient client, IUrlDesignerRepository urlDesignerRepository)
        {
            _userRepository = userRepository;
            _client = client;
            _urlDesignerRepository = urlDesignerRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Create()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_urlDesignerRepository.getUrl("users"));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<User>>(responseBody);

                data.ForEach((userItem) =>
                {
                    User user = new User()
                    {
                        Id = userItem.Id,
                        Name = userItem.Name,
                        Username = userItem.Username,
                        Email = userItem.Email,
                        Phone = userItem.Phone,
                        Website = userItem.Website
                        Companies = userItem.Companies,
                        Addresses = userItem.Addresses
                    };
                    _userRepository.CreateUser(user);

                });
                return Ok(data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message : {0}", e.Message);
                return BadRequest();
            }
            
        }

        
    }
}
