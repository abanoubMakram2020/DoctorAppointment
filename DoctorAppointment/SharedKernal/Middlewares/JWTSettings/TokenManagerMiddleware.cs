using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.JWTSettings
{
    public class TokenManagerMiddleware
    {
        //private readonly ITokenManagerService _tokenManager;

        //public TokenManagerMiddleware(ITokenManagerService tokenManager)
        //{
        //    _tokenManager = tokenManager;

        //}

        //public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        //{
        //    if (await _tokenManager.IsCurrentActiveToken())
        //    {
        //        await next(context);

        //        return;
        //    }
        //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //}

    }
}
