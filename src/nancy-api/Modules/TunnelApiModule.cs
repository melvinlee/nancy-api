using System;
using System.Globalization;
using Nancy;
using NancyApi.Model;
using nancyapi.Repository;

namespace NancyApi.Modules
{
    public class TunnelApiModule : NancyModule
    {
        public TunnelApiModule(TunnelRepository tunnelRepository)
            : base("api/tunnel")
        {
            Before += ctx =>
            {
                ctx.Items.Add("start_time", DateTime.UtcNow);
                return null;
            };

            After += ctx =>
            {
                var processTime = (DateTime.UtcNow - (DateTime)ctx.Items["start_time"]).TotalMilliseconds;
                ctx.Response.WithHeader("x-processing-time", processTime.ToString(CultureInfo.InvariantCulture));
            };

            Get["/"] = p => Response.AsJson(tunnelRepository.Tunnels);

            Get["/{id}"] = p => Response.AsJson((Tunnel)tunnelRepository.Get(p.id));

        }
    }
}