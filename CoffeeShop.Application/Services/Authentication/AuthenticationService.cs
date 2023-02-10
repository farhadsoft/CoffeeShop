using CoffeeShop.Application.Common.Interfaces.Authentication;

namespace CoffeeShop.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationServive
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(
        string login,
        string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            login,
            "token"
        );
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string token)
    {
        Guid userId = Guid.NewGuid();

        token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }
}
