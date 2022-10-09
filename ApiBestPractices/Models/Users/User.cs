using ApiBestPractices.Models.Albums;
using ApiBestPractices.Models.Posts;
using ApiBestPractices.Models.Todos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Collections.Generic;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
        public Address Address { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Todo> Todos { get; set; }
        public ICollection<Album> Albums { get; set; }

        public User()
        {
            if (Address != null)
            {
                int addressId = 0;
                Address.Id = addressId + 1;
            }
            
        }


    }
}
