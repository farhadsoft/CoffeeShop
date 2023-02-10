using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}