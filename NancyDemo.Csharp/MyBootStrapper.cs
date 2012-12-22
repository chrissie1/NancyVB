using Nancy;
using Nancy.TinyIoc;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp
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
