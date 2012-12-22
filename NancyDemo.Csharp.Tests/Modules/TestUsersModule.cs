using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Testing;
using Nancy.ViewEngines.Razor;
using NancyDemo.Csharp.Modules;
using NancyDemo.Csharp.Security;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Tests.Modules
{
    [TestFixture]
    public class TestUsersModule
    {
        private Browser _notLoggedInBrowser;
        private BrowserResponse _loggedInBrowserResponse;

        [SetUp()]
        public void FixtureSetup()
        {
            var formsAuthenticationConfiguration = new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/login",
                    UserMapper = new FakeUserMapper(new UserService())
                };
            var configuration = A.Fake<IRazorConfiguration>();
            var bootstrapper = new ConfigurableBootstrapper(config =>
                {
                    config.Module<UsersModule>();
                    config.Module<LoginModule>();
                    config.ViewEngine(new RazorViewEngine(configuration));
                });
            var bootstrapper2 = new ConfigurableBootstrapper(config =>
                {
                    config.Module<UsersModule>();
                    config.Module<LoginModule>();
                    config.ViewEngine(new RazorViewEngine(configuration));
                    config.RequestStartup((x, pipelines, z) => FormsAuthentication.Enable(pipelines, formsAuthenticationConfiguration));
                });
            _notLoggedInBrowser = new Browser(bootstrapper);
            _loggedInBrowserResponse = new Browser(bootstrapper2).Post("/login", x =>
                {
                    x.HttpRequest();
                    x.FormValue("Username", "Chris1");
                    x.FormValue("Password", "123");
                });
        }

        [Test]
        public void IfPlantsRouteReturnsStatusCodeUnAuthorized()
        {
            var result = _notLoggedInBrowser.Get("/users", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId1RouteReturnsStatusCodeUnAuthorized()
        {
            var result = _notLoggedInBrowser.Get("/users/1", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Test]
        public void IfUserssAuthenticatedReturnsStatusCodeOk()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdabcRouteReturnsStatusCodeOk()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users/abc", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId2ReturnsStatusOk()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users/00000000-0000-0000-0000-000000000004", x =>
                {
                    x.HttpRequest();
                });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId2ReturnsWebpagePlantWithId2()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users/00000000-0000-0000-0000-000000000004", x =>
                {
                    x.HttpRequest();
                });
            Assert.AreEqual("00000000-0000-0000-0000-000000000004", result.BodyAsXml().Descendants("td").ToList()[1].Value);
        }

        [Test]
        public void IfPlantWithId10ReturnsStatusCodeNotFound()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users/10", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdReturnsStatusCodeNotFound()
        {
            var result = _loggedInBrowserResponse.Then.Get("/users/-1", x =>
            {
                x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}