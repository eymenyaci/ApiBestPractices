using ApiBestPractices.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ApiBestPractices.Models.Users;
using ApiBestPractices.Models.Posts;

namespace ApiBestPractices.Services
{
    public class UserService : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            using (var BPDbContext = new BPDbContext())
            {
                //bool anyItem = await BPDbContext.Users.AnyAsync(x => x.Id == user.Id);
                
                await BPDbContext.Users.AddAsync(user);
                
                await BPDbContext.SaveChangesAsync();

                return user;

            }
        }

        public async Task DeleteUser(int id)
        {
            using(var BPDbContext = new BPDbContext())
            {
                var deletedUser = await GetByUserId(id);
                if (deletedUser!=null)
                    BPDbContext.Users.Remove(deletedUser);
                await BPDbContext.SaveChangesAsync();
 
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.ToListAsync();
            }
        }

        public Task<User> GetByUserId(int id)
        {
           using (BPDbContext BPDbContext = new BPDbContext())
            {
                return BPDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.FirstOrDefaultAsync(x=>x.Email == email);
            }
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.FirstOrDefaultAsync(x=>x.Phone == phone);
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.FirstOrDefaultAsync(x=>x.Username == username);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using(BPDbContext BPDbContext = new BPDbContext())
            {
                var updatedUser = await BPDbContext.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                if (updatedUser != null)
                {
                    updatedUser.Name = user.Name;
                    updatedUser.Username = user.Username;
                    updatedUser.Email = user.Email;
                    updatedUser.Phone = user.Phone;
                    updatedUser.Website = user.Website;
                    updatedUser.Companies = user.Companies;
                    updatedUser.Addresses = user.Addresses;
                }

                BPDbContext.Users.Update(updatedUser);
                await BPDbContext.SaveChangesAsync();

                return updatedUser;

                
            }
        }
    }
}
