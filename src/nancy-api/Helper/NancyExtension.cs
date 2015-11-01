using System.Linq;
using Nancy.Bootstrapper;

namespace NancyApi.Helper
{
    public static class NancyExtension
    {
        public static void EnableCors(this IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
                {
                    if (ctx.Request.Headers.Keys.Contains("Origin"))
                    {
                        var origins = "" + string.Join(" ", ctx.Request.Headers["Origin"]);
                        ctx.Response.Headers["Access-Control-Allow-Origin"] = origins;

                        if (ctx.Request.Method == "OPTIONS")
                        {
                            // handle CORS preflight request
                            ctx.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";

                            if (ctx.Request.Headers.Keys.Contains("Access-Control-Request-Headers"))
                            {
                                var allowedHeaders = "" + string.Join(", ",ctx.Request.Headers["Access-Control-Request-Headers"]);
                                ctx.Response.Headers["Access-Control-Allow-Headers"] = allowedHeaders;
                            }
                        }
                    }
                });
        }
    }
}