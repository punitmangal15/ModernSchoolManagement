using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;

namespace ModernSchoolManagement.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;
        private static readonly HashSet<string> _excludedPaths = new(StringComparer.OrdinalIgnoreCase)
        {
            "/api/account/login",
            "/api/account/create",
            "/weatherforecast"
        };

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IAuthentication authentication)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (authentication == null)
            {
                throw new ArgumentNullException(nameof(authentication));
            }
            var requestPath = context.Request.Path.Value?.ToLowerInvariant();

            if (_excludedPaths.Contains(requestPath))
            {
                _logger.LogInformation("Request path '{Path}' is excluded from authentication.", requestPath);

                await _next(context);
                return;
            }
            string Toke = context.Request.Headers.Authorization;
            bool ValidToken = false;
            if (string.IsNullOrEmpty(Toke))
            {
                ValidToken = authentication.ValidateTokenCLaim(Toke);

            }
            if (ValidToken)
            {
                try
                {
                    await _next(context); return;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error processing request: {Message}", ex.Message);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("Internal Server Error");
                    return;

                }

            }
            else
            {
                _logger.LogWarning("Unauthorized access attempt to '{Path}'", requestPath);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }
    }
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
