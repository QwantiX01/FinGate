using Authentication.Contracts;

namespace Authentication.Api;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuth(this IEndpointRouteBuilder builder)
    {
        var authGroup = builder.MapGroup("api/auth");

        authGroup.MapPost("/register",
            async (UserRegisterContract registerContract) => { throw new NotImplementedException(); });

        authGroup.MapPost("/sign-up",
            async (UserLoginContract signUpContract) => { throw new NotImplementedException(); });

        authGroup.MapPost("/logout",
            async () => { throw new NotImplementedException(); }).RequireAuthorization();

        authGroup.MapPost("/refresh-token",
            async (TokenRefreshContract refreshContract) => { throw new NotImplementedException(); });

        return builder;
    }
}