using Nancy;
using Nancy.Responses.Negotiation;

namespace NancyApi
{
    public static class NegotiateExtensions
    {
        public static Negotiator AsGetResponse(this Negotiator negotiator, object model)
        {
            return negotiator.AsXmlJsonReponse(model);
        }

        public static Negotiator AsPostReponse(this Negotiator negotiator, object model)
        {
            return negotiator.AsXmlJsonReponse(model, HttpStatusCode.Accepted);
        }

        public static Negotiator AsXmlJsonReponse(this Negotiator negotiator, object model, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            if (model == null)
            {
                httpStatusCode = HttpStatusCode.NoContent;
            }

            return negotiator.WithModel(model)
                .WithAllowedMediaRange(new MediaRange("application/xml"))
                .WithAllowedMediaRange(new MediaRange("application/json"))
                .WithStatusCode(httpStatusCode);
        }
    }
}