using CoffeeShop.Application.Common.Interfaces.Authentication;
using CoffeeShop.Infrastructure.Authentication;
using CoffeeShop.Application.Common.Interfaces.Persistence;
using CoffeeShop.Infrastructure.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}