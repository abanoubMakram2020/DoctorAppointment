using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SharedKernal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointment.Presentation.API.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var claims = new Dictionary<string, string>();
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var header = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
                if (header != null)
                {
                    try
                    {
                        claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(GeneralUtilities.Decrypt(header.Parameter));
                    }
                    catch (Exception)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }
}
