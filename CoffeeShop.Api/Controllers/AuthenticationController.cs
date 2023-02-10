using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Contracts.Authentication;
using CoffeeShop.Application.Services.Authentication;

namespace CoffeeShop.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationServive _authenticationService;

    public AuthenticationController(IAuthenticationServive authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authRequest = _authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponce(
            authRequest.User.Id,
            authRequest.User.FirstName,
            authRequest.User.LastName,
            authRequest.User.Email,
            authRequest.Token
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authRequest = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponce(
            authRequest.User.Id,
            authRequest.User.FirstName,
            authRequest.User.LastName,
            authRequest.User.Email,
            authRequest.Token
        );

        return Ok(response);
    }
}