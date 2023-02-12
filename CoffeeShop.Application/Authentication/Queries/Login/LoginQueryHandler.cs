using CoffeeShop.Application.Authentication.Common;
using CoffeeShop.Application.Common.Interfaces.Authentication;
using CoffeeShop.Application.Common.Interfaces.Persistence;
using CoffeeShop.Domain.Entities;
using MediatR;

namespace CoffeeShop.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            throw new Exception("The user is already exists");
        }

        if (user.Password != request.Password)
        {
            throw new Exception("The password is not correct");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}
