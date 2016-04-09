using Nancy.Model;

namespace Nancy.WebAPI.Modules
{
    public static class TunnelResponseExtensions
    {
        public static Response AsNewTunnel(this IResponseFormatter formatter, Tunnel tunnel)
        {
            var url = $"{formatter.Context.Request.Url}/{tunnel.Id}";

            return new Response()
                {
                    StatusCode = HttpStatusCode.Accepted
                }.WithHeader("Location", url);
        }
    }
}