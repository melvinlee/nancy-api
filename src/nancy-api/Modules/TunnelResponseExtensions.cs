using Nancy;
using NancyApi.Model;

namespace NancyApi.Modules
{
    public static class TunnelResponseExtensions
    {
        public static Response AsNewTunnel(this IResponseFormatter formatter, Tunnel tunnel)
        {
            var url = string.Format("{0}/{1}", formatter.Context.Request.Url, tunnel.Id);

            return new Response()
                {
                    StatusCode = HttpStatusCode.Accepted
                }.WithHeader("Location", url);
        }
    }
}