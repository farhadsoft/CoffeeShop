using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);