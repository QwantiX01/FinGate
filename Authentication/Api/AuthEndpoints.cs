using Authentication.Contracts;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuth(this IEndpointRouteBuilder builder)
    {
        var authGroup = builder.MapGroup("api/auth");

        authGroup.MapPost("/register",
            async (UserRegisterContract registerContract, IAuthService authService) =>
            {
                try
                {
                    var tokenPair = await authService.RegisterAsync(registerContract);
                    return Results.Ok(tokenPair);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

        authGroup.MapPost("/login",
            async (UserLoginContract loginContract, IAuthService authService) =>
            {
                try
                {
                    var tokenPair = await authService.LoginAsync(loginContract);
                    return Results.Ok(tokenPair);
                }
                catch (Exception ex)
                {
                    return Results.Unauthorized();
                }
            });

        authGroup.MapPost("/refresh-token",
            async (TokenRefreshContract refreshContract, IAuthService authService) =>
            {
                try
                {
                    var tokenPair = await authService.RefreshTokenAsync(refreshContract);
                    return Results.Ok(tokenPair);
                }
                catch (Exception ex)
                {
                    return Results.Unauthorized();
                }
            });

        return builder;
    }
}