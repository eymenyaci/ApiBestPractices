using ApiBestPractices.Models.Albums;
using ApiBestPractices.Models.Comments;
using ApiBestPractices.Models.Photos;
using ApiBestPractices.Models.Posts;
using ApiBestPractices.Models.Todos;
using ApiBestPractices.Models.Users;
using Microsoft.EntityFrameworkCore;



namespace ApiBestPractices.Models.Context
{
    public class BPDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }

        public BPDbContext(DbContextOptions<BPDbContext> options) : base (options)
        {

        }

        public BPDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JFVV9NF;Database=JsonPlaceHolderDB;User Id=sa;Password=eymen123");
        }

        
    }

        

        
        
    
}
