using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyHealth.Application.Abstractions.Persistence;
using MyHealth.Application.Common.Auth;
using MyHealth.Application.Services.Auth;
using MyHealth.Application.Services.Security;
using MyHealth.Domain.Entities.Identity;
using MyHealth.Persistence.Contexts;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var jwt = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtSettings>()
    ?? throw new Exception("JWT settings missing");

// AUTH
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwt.Key))
        };
});

builder.Services.AddAuthorization();

// DB
builder.Services.AddDbContext<MyHealthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IPersistenceContext>(
    provider => provider.GetRequiredService<MyHealthDbContext>());

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<JwtTokenService>();

builder.Services.AddControllers();

var app = builder.Build();

// Seed admin
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<MyHealthDbContext>();

    if (!db.Users.Any())
    {
        var hasher = new PasswordHasher();

        var user = new User
        {
            UserName = "admin",
            PasswordHash = hasher.Hash("123456"),
            FirstName = "System",
            LastName = "Admin",
            PhoneNumber = "+10000000000"
        };

        db.Users.Add(user);

        db.SaveChanges();
    }
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();