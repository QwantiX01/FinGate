using Authentication.Contracts;
using Authentication.Models;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuth(this IEndpointRouteBuilder builder)
    {
        var authGroup = builder.MapGroup("api/auth");

        // api/auth/register
        authGroup.MapPost("/register",
                async (UserRegisterContract registerContract, IAuthService authService) =>
                {
                    try
                    {
                        var tokenPair = await authService.RegisterAsync(registerContract);
                        return Results.Ok(tokenPair);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(new { message = e.Message });
                    }
                })
            .Produces<TokenPair>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Registers a new user");

        // api/auth/login
        authGroup.MapPost("/login",
                async (UserLoginContract loginContract, IAuthService authService) =>
                {
                    try
                    {
                        var tokenPair = await authService.LoginAsync(loginContract);
                        return Results.Ok(tokenPair);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(new { message = e.Message });
                    }
                })
            .Produces<TokenPair>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Logs in a user");

        // api/auth/logout
        authGroup.MapPost("/logout",
                async (IAuthService authService) =>
                {
                    try
                    {
                        await authService.LogoutAsync();
                        return Results.NoContent();
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(new { message = e.Message });
                    }
                })
            .RequireAuthorization()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Logs out the current user");

        // api/auth/refresh-token
        authGroup.MapPost("/refresh-token",
                async (TokenRefreshContract refreshContract, IAuthService authService) =>
                {
                    try
                    {
                        var tokenPair = await authService.RefreshTokenAsync(refreshContract);
                        return Results.Ok(tokenPair);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(new { message = e.Message });
                    }
                })
            .Produces<TokenPair>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Refreshes an access token");

        return builder;
    }
}