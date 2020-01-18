using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commentsApi.middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IToken _securityService;
        public TokenMiddleware(RequestDelegate next, IToken securityService)
        {
            _next = next;
            _securityService = securityService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"];
            var methodType = context.Request.Method;
            if (token.Count == 0)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("ApiKey is empty");
            }
            var isTokenValid = await _securityService.IsValid(token, methodType);
            if (!isTokenValid)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("ApiKey is invalid");
            }
        }
    }
}
