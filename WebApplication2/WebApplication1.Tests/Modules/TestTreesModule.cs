using FakeItEasy;
using WebApplication1.Modules;
using Nancy;
using NUnit.Framework;
using Nancy.Testing;
using Nancy.ViewEngines.Razor;

namespace WebApplication1.Tests.Modules
{
    [TestFixture]
    public class TestTreesModule
    {
        private Browser _browser;

        [SetUp()]
        public void FixtureSetup()
        {
            var configuration = A.Fake<IRazorConfiguration>();
            var bootstrapper = new ConfigurableBootstrapper(config =>
                {
                    config.Module<TreesModule>();
                    config.ViewEngine(new RazorViewEngine(configuration));
                });
            _browser = new Browser(bootstrapper);
        }

        [Test]
        public void IfPlantsRouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/trees", x => {
                                                         x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId1RouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/trees/1", x => {
                                                           x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdabcRouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/trees/abc", x => {
                                                             x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId2ReturnsWebpagePlantWithId2()
        {
            var result = _browser.Get("/trees/2", x => {
                                                           x.HttpRequest();
            });
            Assert.AreEqual("2", result.BodyAsXml().Descendants("td"));
        }

        [Test]
        public void IfPlantAddReturnsStatusCodeOk()
        {
            var result = _browser.Get("/trees/add/", x => {
                                                              x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantAddReturnsBody()
        {
            var result = _browser.Get("/trees/add/", x => {
                                                              x.HttpRequest();
            });
            Assert.AreEqual("Add tree page", result.BodyAsXml().Element("title").Value);
        }

        [Test]
        public void IfPlantWithId10ReturnsStatusCodeNotFound()
        {
            var result = _browser.Get("/trees/10", x => {
                                                            x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdReturnsStatusCodeNotFound()
        {
            var result = _browser.Get("/trees/-1", x => {
                                                            x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}