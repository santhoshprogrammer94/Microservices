﻿namespace PetFoodShop.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using PetFoodShop.Services;
    using System.Linq;
    using System.Threading.Tasks;
    using static InfrastructureConstants.AuthConstants;

    public class JwtHeaderAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentTokenService currentToken;

        public JwtHeaderAuthenticationMiddleware(ICurrentTokenService currentToken)
        {
            this.currentToken = currentToken;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers[AuthorizationHeaderName].ToString();

            if (!string.IsNullOrWhiteSpace(token))
            {
                this.currentToken.Set(token.Split().Last());
            }

            await next.Invoke(context);
        }
    }
}
