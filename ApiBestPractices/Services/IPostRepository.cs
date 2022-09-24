using ApiBestPractices.Models.Context;
using ApiBestPractices.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBestPractices.Services
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetPostByUserId(int userId);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(int id);
    }
}
