using ApiBestPractices.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBestPractices.Services
{
    public class PostService : IPostRepository
    {
        public Task<Post> CreatePost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePost(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Post>> GetAllPosts()
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> GetPostById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> GetPostByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> UpdatePost(Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}
