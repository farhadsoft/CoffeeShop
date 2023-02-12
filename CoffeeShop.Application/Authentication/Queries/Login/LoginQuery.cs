using CoffeeShop.Application.Authentication.Common;
using MediatR;

namespace CoffeeShop.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
