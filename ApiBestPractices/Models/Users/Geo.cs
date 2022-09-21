using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Geo
    {
        [Key]
        public int GeoId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public virtual Address Address { get; set; }    
        
    }
}
