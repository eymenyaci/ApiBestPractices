using ApiBestPractices.Models.Users;
using System.Data.Entity;

namespace ApiBestPractices.Models.Todos
{
    public class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Complated { get; set; }
        public User User { get; set; }
    }
}
