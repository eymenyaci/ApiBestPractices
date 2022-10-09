using ApiBestPractices.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBestPractices.Models.Users;


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

                List<User> lastUserList = new List<User>();
                var userList = await BPDbContext.Users.ToListAsync();
                var addresses = await BPDbContext.Addresses.ToListAsync();
                var geos = await BPDbContext.Geos.ToListAsync();
                var companies = await BPDbContext.Companies.ToListAsync();

                foreach (var userItem in userList)
                {

                    if (userItem != null)
                    {
                        var address = addresses.Where(a => a.UserId == userItem.Id).FirstOrDefault();
                        var geo = geos.Where(g => g.AddressId == address.Id).FirstOrDefault();
                        var company = companies.Where(c => c.UserId == userItem.Id).FirstOrDefault();
                        address.Geo = geo;
                        userItem.Address = address;
                        userItem.Company = company;
                        lastUserList.Add(userItem);
                    }

                }

                return lastUserList;

            }
        }

        public async Task<User> GetByUserId(int id)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var users = await GetAllUser();
                User user = users.FirstOrDefault(u => u.Id == id);
                return user;
                
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var users = await GetAllUser();
                User user = users.FirstOrDefault(u => u.Email == email);
                return user;
            }
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var users = await GetAllUser();
                User user = users.FirstOrDefault(u => u.Phone == phone);
                return user;
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var users = await GetAllUser();
                User user = users.FirstOrDefault(u => u.Username == username);
                return user;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (BPDbContext BPDbContext = new BPDbContext())
            {
                var updatedUser = await GetByUserId(user.Id);
                if (updatedUser != null)
                {
                    updatedUser.Name = user.Name;
                    updatedUser.Username = user.Username;
                    updatedUser.Email = user.Email;
                    updatedUser.Phone = user.Phone;
                    updatedUser.Website = user.Website;

                    /*=============Address=================*/

                    updatedUser.Address.Street = user.Address.Street;
                    updatedUser.Address.City = user.Address.City;
                    updatedUser.Address.Suite = user.Address.Suite;
                    updatedUser.Address.ZipCode = user.Address.ZipCode;
                    updatedUser.Address.Geo.Lat = user.Address.Geo.Lat;
                    updatedUser.Address.Geo.Lng = user.Address.Geo.Lng;

                    /*=============Company=================*/

                    updatedUser.Company.Name = user.Company.Name;
                    updatedUser.Company.CatchPhrase = user.Company.CatchPhrase;
                    updatedUser.Company.Bs = user.Company.Bs;

                }

                BPDbContext.Users.Update(updatedUser);
                await BPDbContext.SaveChangesAsync();

                return updatedUser;


            }
        }
    }
}
