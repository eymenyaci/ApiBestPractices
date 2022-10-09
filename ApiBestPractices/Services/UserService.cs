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
                if (user != null)
                {
                    bool anyChanges = false;
                    bool hasUser = BPDbContext.Users.Where(u => u.Username == user.Username).Any();
                    if (!hasUser)
                    {
                        await BPDbContext.Users.AddAsync(user);
                        anyChanges = true;
                    }
                    bool hasUserAddress = BPDbContext.Addresses.Where(a => a.UserId == user.Address.UserId).Any();
                    if (!hasUserAddress)
                    {
                        await BPDbContext.Addresses.AddAsync(user.Address);
                        anyChanges = true;
                    }
                    bool hasUserCompany = BPDbContext.Companies.Where(a => a.UserId == user.Company.UserId).Any();
                    if (!hasUserCompany)
                    {
                        await BPDbContext.Companies.AddAsync(user.Company);
                        anyChanges = true;
                    }
                    bool hasAddressGeo = BPDbContext.Geos.Where(a => a.AddressId == user.Address.Geo.AddressId).Any();
                    if (!hasAddressGeo)
                    {
                        await BPDbContext.Geos.AddAsync(user.Address.Geo);
                        anyChanges = true;
                    }
                    if (anyChanges)
                    {
                        await BPDbContext.SaveChangesAsync();
                    }

                }
                return user;

            }
        }

        public async Task DeleteUser(int id)
        {
            using (var BPDbContext = new BPDbContext())
            {
                var deletedUser = await GetByUserId(id);
                if (deletedUser != null)
                    BPDbContext.Users.Remove(deletedUser);
                await BPDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<User>> GetAllUser()
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                
                var users = await BPDbContext.Users.ToListAsync();
                return users;
                
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
                return await BPDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            }
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.FirstOrDefaultAsync(x => x.Phone == phone);
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                return await BPDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var updatedUser = await BPDbContext.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                if (updatedUser != null)
                {
                    updatedUser.Name = user.Name;
                    updatedUser.Username = user.Username;
                    updatedUser.Email = user.Email;
                    updatedUser.Phone = user.Phone;
                    updatedUser.Website = user.Website;
                    
                }

                BPDbContext.Users.Update(updatedUser);
                await BPDbContext.SaveChangesAsync();

                return updatedUser;


            }
        }
    }
}
