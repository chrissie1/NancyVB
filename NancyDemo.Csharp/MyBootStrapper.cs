using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyDemo.Csharp.Processors;
using NancyDemo.Csharp.Security;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp
{
    public class MyBootStrapper : DefaultNancyBootstrapper
    {

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<BushService>().AsSingleton();
            container.Register<TreeService>().AsSingleton();
            container.Register<UserService>().AsSingleton();
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            container.Register<IUserMapper, FakeUserMapper>();
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            var formsAuthConfiguration = new FormsAuthenticationConfiguration
                {
                    RedirectUrl = "~/login",
                    UserMapper = container.Resolve<IUserMapper>()
                };
            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
    }
}
