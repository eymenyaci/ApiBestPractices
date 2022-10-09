using ApiBestPractices.Models.Posts;
using ApiBestPractices.Models.Users;
using ApiBestPractices.Services;
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
        private IUserRepository _userRepository;
        private IUrlDesignerRepository _urlDesignerRepository;

        public UsersController(HttpClient client, IUserRepository userRepository, IUrlDesignerRepository urlDesignerRepository)
        {
            _client = client;
            _userRepository = userRepository;
            _urlDesignerRepository = urlDesignerRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateUser()
        {
            HttpResponseMessage response = await _client.GetAsync(_urlDesignerRepository.getUrl("users"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<User>>(responseBody);
            data.ForEach(async (userItem) =>
            {

                Geo geo = new Geo()
                {
                    AddressId = userItem.Id,
                    Lat = Convert.ToDouble(userItem.Address.Geo.Lat),
                    Lng = Convert.ToDouble(userItem.Address.Geo.Lng),
                };

                Address address = new Address()
                {
                    UserId = userItem.Id,
                    City = Convert.ToString(userItem.Address.City),
                    Street = Convert.ToString(userItem.Address.Street),
                    Suite = Convert.ToString(userItem.Address.Suite),
                    ZipCode = Convert.ToString(userItem.Address.ZipCode),
                    Geo = geo
                };

                Company company = new Company()
                {
                    UserId = userItem.Id,
                    Name = userItem.Company.Name,
                    CatchPhrase = userItem.Company.CatchPhrase,
                    Bs = userItem.Company.Bs
                };

                User user = new User()
                {
                    Name = userItem.Name,
                    Username = userItem.Username,
                    Email = userItem.Email,
                    Phone = userItem.Phone,
                    Website = userItem.Website,
                    Address = address,
                    Company = company
                };

                await _userRepository.CreateUser(user);
            });

            return Ok(data);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_userRepository.GetByUserId(id) != null)
            {
                await _userRepository.DeleteUser(id);
                return Ok(id + " deleted");
            }

            return BadRequest();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var allUser = await _userRepository.GetAllUser();
            return Ok(allUser);
        }

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (_userRepository.GetByUserId(id) != null)
            {
                var user = await _userRepository.GetByUserId(id);
                return Ok(user);
            }
            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{Email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (email != null)
            {
                var user = await _userRepository.GetUserByEmail(email);
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{Phone}")]
        public async Task<IActionResult> GetUserByPhone(string phone)
        {
            if (phone != null)
            {
                var user = await _userRepository.GetUserByPhone(phone);
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{Username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            if (username != null)
            {
                var user = await _userRepository.GetUserByUsername(username);
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            if (user != null && user.Id!=0)
            {
                var updatedUser = await _userRepository.UpdateUser(user);
                return Ok(updatedUser);
            }

            return BadRequest();


        }


    }
}
