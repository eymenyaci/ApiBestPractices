using ApiBestPractices.Models.Context;
using ApiBestPractices.Models.Posts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                bool anyItem = await BPDbContext.Posts.AnyAsync(x => x.Id == post.Id);
                if (!anyItem)
                    await BPDbContext.Posts.AddAsync(post);
                await BPDbContext.SaveChangesAsync();
                return post;

            }
        }

        public async Task DeletePost(int id)
        {
            using (var BPDbContext = new BPDbContext())
            {
                var deletedPost = await GetPostById(id);
                if (deletedPost != null)
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
                return await BPDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<List<Post>> GetPostByUserId(int userId)
        {
            using (var BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Posts.Where(x => x.UserId == userId).ToListAsync();

            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            using (var BPDbContext = new BPDbContext())
            {
                var updatedPost = await BPDbContext.Posts.Where(x => x.Id == post.Id).FirstOrDefaultAsync();
                if (post != null)
                {
                    updatedPost.Title = post.Title;
                    updatedPost.UserId = post.UserId;
                    updatedPost.Body = post.Body;
                }
                await BPDbContext.SaveChangesAsync();
                return updatedPost;

            }
        }
    }
}
