namespace CoffeeShop.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationServive
{
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
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
    }
}
