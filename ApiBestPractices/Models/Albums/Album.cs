using ApiBestPractices.Models.Users;
using System.Data.Entity;

namespace ApiBestPractices.Models.Albums
{
    public class Album
    {
        public int UserId  { get; set; }
        public int Id  { get; set; }
        public string Title  { get; set; }
        public User User { get; set; }
    }
}
