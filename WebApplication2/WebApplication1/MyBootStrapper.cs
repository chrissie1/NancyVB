using Nancy;
using Nancy.TinyIoc;
using WebApplication1.Services;

namespace WebApplication1
{
    public class MyBootStrapper : DefaultNancyBootstrapper
    {
    

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<BushService>().AsSingleton();
            container.Register<TreeService>().AsSingleton();
        }
    }
}
