using System;
using System.Collections.Generic;
using System.Globalization;
using Nancy.Model;
using Nancy.Model.Dto;
using Nancy.ModelBinding;
using Nancy.Repository;

namespace Nancy.WebAPI.Modules
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

            Get["/"] = p =>
            {
                var dto = new TunnelsDto();
                dto.Tunnels = new List<Tunnel>(tunnelRepository.Tunnels);
                
                return Negotiate.AsGetResponse(dto);
            };

            Get["/{id}"] = p =>
                {
                    var response = tunnelRepository.Get(p.id);

                    return response == null ? HttpStatusCode.NotFound : Response.AsJson((Tunnel)response);
                };

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

            Delete["/{id}"] = p =>
                {
                    double outvalue;
                    if (!double.TryParse(p.id, out outvalue)) return HttpStatusCode.NoContent;

                    return tunnelRepository.Delete(p.id) ? HttpStatusCode.Accepted : HttpStatusCode.NoContent;
                };
        }
    }
}