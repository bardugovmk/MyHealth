using MyHealth.Application.DTOs.Auth;

namespace MyHealth.Application.Services.Auth;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
}