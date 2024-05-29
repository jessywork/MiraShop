﻿using MiraShop.API.Services;

namespace MiraShop.API.Middlewares
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICurrentUserService currentUserService)
        {
            var isAuthenticated = context.User.Identity!.IsAuthenticated;

            if (isAuthenticated)
            {
                await currentUserService.AuthenticateUser(context.User);
            }

            await _next(context);
        }
    }

    public static class CurrentUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseCurrentUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurrentUserMiddleware>();
        }
    }

}
