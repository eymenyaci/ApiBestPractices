using ApiBestPractices.Models.Context;
using ApiBestPractices.Models.Posts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace ApiBestPractices.Services
{
    public class PostService : IPostRepository
    {
        public async Task<Post> CreatePost(Post post)
        {
            using (var BPDbContext = new BPDbContext())
            {
                BPDbContext.Posts.Add(post);
                await BPDbContext.SaveChangesAsync();
                return post;

            }
        }

        public async Task DeletePost(int id)
        {
            using (var BPDbContext = new BPDbContext())
            {
                var deletedPost = await GetPostById(id);
                BPDbContext.Posts.Remove(deletedPost);
                await BPDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            using (var BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Posts.ToListAsync();
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Posts.FindAsync(id);
            }
        }

        public async Task<Post> GetPostByUserId(int userId)
        {
            using (var BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Posts.FindAsync(userId);
            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            using (var BPDbContext = new BPDbContext())
            {
                BPDbContext.Posts.Update(post);
                await BPDbContext.SaveChangesAsync();
                return post;
            }
        }
    }
}
