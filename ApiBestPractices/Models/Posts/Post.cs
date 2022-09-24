using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBestPractices.Models.Posts
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Title { get; set;}
        public string Body { get; set; }
    }
}
