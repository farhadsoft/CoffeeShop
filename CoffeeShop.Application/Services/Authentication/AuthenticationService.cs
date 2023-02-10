using CoffeeShop.Application.Common.Interfaces.Authentication;
using CoffeeShop.Application.Common.Interfaces.Persistence;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationServive
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(
        string login,
        string password)
    {
        if (_userRepository.GetUserByEmail(login) is not User user)
        {
            throw new Exception("The user is already exists");
        }

        if (user.Password != password)
        {
            throw new Exception("The password is not correct");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("The user is already exists");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
        );
    }
}
