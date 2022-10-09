using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Company
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        public User User { get; set; }
    }
}
