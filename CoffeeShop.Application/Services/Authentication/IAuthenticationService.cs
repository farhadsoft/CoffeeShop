namespace CoffeeShop.Application.Services.Authentication;

public interface IAuthenticationServive
{
    public AuthenticationResult Login(string login, string password);
    public AuthenticationResult Register(string firstName, string lastName, string email, string token);
}