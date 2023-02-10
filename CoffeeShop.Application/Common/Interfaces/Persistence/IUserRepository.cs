using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
