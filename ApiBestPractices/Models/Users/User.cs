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
        public ICollection<Company> Companies { get; set; }
        public  ICollection<Address> Addresses { get; set; }

        public User()
        {
            List<Address> addresses = new List<Address>();
            List<Company> companies = new List<Company>();
        }

    }
}
