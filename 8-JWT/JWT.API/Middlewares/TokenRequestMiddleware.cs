using Microsoft.AspNetCore.Builder;

namespace JWT.API.Middlewares
{
    public static class TokenRequestMiddleware
    {
        public static IApplicationBuilder UseTokenMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<TokenRequestHandler>();
            return builder;
        }
    }
}
