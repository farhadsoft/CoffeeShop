using Microsoft.AspNetCore.Mvc;
using MediatR;
using CoffeeShop.Application.Authentication.Commands.Register;
using CoffeeShop.Application.Authentication.Queries.Login;
using CoffeeShop.Application.Authentication.Common;
using CoffeeShop.Contracts.Authentication;

namespace CoffeeShop.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        AuthenticationResult authRequest = await _sender.Send(query);

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
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        AuthenticationResult authRequest = await _sender.Send(command);

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