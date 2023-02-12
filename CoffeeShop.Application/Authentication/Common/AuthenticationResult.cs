using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);