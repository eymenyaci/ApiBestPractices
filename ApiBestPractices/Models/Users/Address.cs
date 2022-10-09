using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Address
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public User User { get; set; }
        public Geo Geo { get; set; }


    }
}
