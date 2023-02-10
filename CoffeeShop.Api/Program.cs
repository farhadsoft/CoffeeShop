using CoffeeShop.Application.Common.Interfaces.Authentication;
using CoffeeShop.Infrastructure.Authentication;
using CoffeeShop.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    builder.Services.AddScoped<IAuthenticationServive, AuthenticationService>();
    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}