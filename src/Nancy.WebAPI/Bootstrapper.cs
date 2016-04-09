using Nancy.Repository;
using Nancy.WebAPI.Helper;

namespace Nancy.WebAPI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            // JsonP support
            Jsonp.Enable(pipelines);

            // Enable CORS
            pipelines.EnableCors();

            // Register repository as singleton for persistant data source
            container.Register<ITunnelRepository,TunnelRepository>().AsSingleton();
        }

        protected override byte[] FavIcon => null;
    }
}