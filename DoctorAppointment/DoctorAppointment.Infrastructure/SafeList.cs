using Microsoft.AspNetCore.Http;
using System.Net;

namespace DoctorAppointment.Infrastructure
{
    public class SafeList
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly string _adminSafeList;
        #endregion

        #region Ctor
        public SafeList(RequestDelegate next, string adminWhiteList)
        {
            _adminSafeList = adminWhiteList;
            _next = next;
        }
        #endregion

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                var remoteIp = context.Connection.RemoteIpAddress;

                string[] ip = _adminSafeList.Split(';');

                var bytes = remoteIp.GetAddressBytes();
                var badIp = true;
                foreach (var address in ip)
                {
                    var testIp = IPAddress.Parse(address);
                    if (testIp.GetAddressBytes().SequenceEqual(bytes))
                    {
                        badIp = false;
                        break;
                    }
                }

                if (badIp)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;
                }
            }
            await _next.Invoke(context);

        }
    }
}
