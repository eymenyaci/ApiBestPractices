using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Geo> Geos { get; set; }

    }
}
