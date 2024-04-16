using Microsoft.AspNetCore.Http;

namespace VideoRentShop.Common
{
    public static class HttpHelper
    {
        public static string GetIp(HttpRequest request, ConnectionInfo connectionInfo)
        {
            // get source ip address for the current request
            if (request.Headers.ContainsKey("X-Forwarded-For"))
                return request.Headers["X-Forwarded-For"];
            else
                return connectionInfo.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
