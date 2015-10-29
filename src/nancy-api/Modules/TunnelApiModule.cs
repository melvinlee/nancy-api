using System;
using System.Globalization;
using Nancy;
using Nancy.ModelBinding;
using NancyApi.Model;
using NancyApi.Repository;

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

            Post["/", c => c.Request.Headers.ContentType != "application/x-www-urlencoded"] = p =>
            {
                var model = this.Bind<Tunnel>();
                tunnelRepository.Add(model);
                return Response.AsNewTunnel(model);
            };

            Post["/"] = p =>
            {
                var model = new Tunnel()
                    {
                        Name = Request.Form.Name,
                        Location = Request.Form.Location,
                        Length = Request.Form.Length,
                        Type = Request.Form.Type,
                        Year = Request.Form.Year
                    };

                var newModel = tunnelRepository.Add(model);
                return Response.AsNewTunnel(newModel);
            };

        }
    }
}