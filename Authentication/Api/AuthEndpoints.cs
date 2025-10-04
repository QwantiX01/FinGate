namespace Authentication.Api;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuth(this IEndpointRouteBuilder builder)
    {
        var authGroup = builder.MapGroup("api/auth");
        
        // POST: api/auth/register
        authGroup.MapPost("/register", async context =>
        {
            throw new NotImplementedException();
        });
        
        // POST: api/auth/sign-up
        authGroup.MapPost("/sign-up", context =>
        {
            throw new NotImplementedException();
        });
        
        // POST: api/auth/logout
        authGroup.MapPost("/logout", context =>
        {
            throw new NotImplementedException();
        }).RequireAuthorization();
        
        // POST: api/auth/refresh-token
        authGroup.MapPost("/refresh-token", context =>
        {
            throw new NotImplementedException();
        });
       
        return builder;
    }
}