using CoffeeShop.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddScoped<IAuthenticationServive, AuthenticationService>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}