using FakeItEasy;
using WebApplication1.Modules;
using Nancy;
using NUnit.Framework;
using Nancy.Testing;
using Nancy.ViewEngines.Razor;

namespace WebApplication1.Tests.Modules
{
    [TestFixture]
    public class TestBushesModule
    {
        private Browser _browser;

        [SetUp()]
        public void FixtureSetup()
        {
            var configuration = A.Fake<IRazorConfiguration>();
            var bootstrapper = new ConfigurableBootstrapper(config =>
                {
                    config.Module<BushesModule>();
                    config.ViewEngine(new RazorViewEngine(configuration));
                });
            _browser = new Browser(bootstrapper);
        }

        [Test]
        public void IfPlantsRouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/bushes", x => {
                                                    x.HttpRequest();
                                                });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId1RouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/bushes/1", x => {
                                                            x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdabcRouteReturnsStatusCodeOk()
        {
            var result = _browser.Get("/bushes/abc", x => {
                                                              x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithId2ReturnsWebpagePlantWithId2()
        {
            var result = _browser.Get("/bushes/2", x => {
                                                            x.HttpRequest();
            });
            Assert.AreEqual("2", result.BodyAsXml().Elements("td"));
        }
        [Test]
        public void IfPlantAddReturnsStatusCodeOk()
        {
            var result = _browser.Get("/bushes/add/", x => {
                                                               x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void IfPlantAddReturnsBody()
        {
            var result = _browser.Get("/bushes/add/", x => {
                                                               x.HttpRequest();
            });
            Assert.AreEqual("Add bush page", result.BodyAsXml().Element("title").Value);
        }

        [Test]
        public void IfPlantWithId10ReturnsStatusCodeNotFound()
        {
            var result = _browser.Get("/bushes/10", x => {
                                                             x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void IfPlantWithIdReturnsStatusCodeNotFound()
        {
            var result = _browser.Get("/bushes/-1", x => {
                                                             x.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

    }
}