using Microsoft.EntityFrameworkCore;
using MyHealth.Application.Abstractions.Persistence;
using MyHealth.Application.DTOs.Auth;
using MyHealth.Application.Services.Security;

namespace MyHealth.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IPersistenceContext _context;
    private readonly PasswordHasher _hasher;
    private readonly JwtTokenService _jwt;

    public AuthService(
        IPersistenceContext context,
        PasswordHasher hasher,
        JwtTokenService jwt)
    {
        _context = context;
        _hasher = hasher;
        _jwt = jwt;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.UserName == request.UserName);

        if (user == null)
            throw new Exception("User not found");

        if (!_hasher.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid password");

        var roles = user.UserRoles
            .Select(x => x.Role.Name)
            .ToList();

        var token = _jwt.CreateToken(user, roles);

        return new AuthResponse
        {
            Token = token,
            UserName = user.UserName
        };
    }
}