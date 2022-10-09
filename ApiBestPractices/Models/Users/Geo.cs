using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Geo
    {
      
        public int Id { get; set; }
        public int AddressId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Address Address { get; set; }    
        
    }
}
