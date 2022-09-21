using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ApiBestPractices.Models.Users
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        public virtual User User { get; set; }
    }
}
