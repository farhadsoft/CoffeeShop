using CoffeeShop.Application.Common.Interfaces.Persistence;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new();
        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(u => u.Email == email);
        }
    }
}
