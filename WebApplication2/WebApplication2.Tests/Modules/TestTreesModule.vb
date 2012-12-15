Imports FakeItEasy
Imports WebApplication2.Modules
Imports Nancy
Imports NUnit.Framework
Imports Nancy.Testing
Imports Nancy.ViewEngines.Razor

Namespace Tests

    <TestFixture>
    Public Class TestTreesModule

        Private _browser As Browser

        <SetUp()>
        Public Sub FixtureSetup()
            Dim configuration = A.Fake(Of IRazorConfiguration)()
            Dim bootstrapper = New ConfigurableBootstrapper(Sub(config)
                                                                config.Module(Of TreesModule)()
                                                                config.ViewEngine(New RazorViewEngine(configuration))
                                                            End Sub)
            _browser = New Browser(bootstrapper)
        End Sub

        <Test>
        Public Sub IfPlantsRouteReturnsStatusCodeOk()
            Dim result = _browser.Get("/trees", Sub(x)
                                                    x.HttpRequest()
                                                End Sub)
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithId1RouteReturnsStatusCodeOk()
            Dim result = _browser.Get("/trees/1", Sub(x)
                                                      x.HttpRequest()
                                                  End Sub)
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithIdabcRouteReturnsStatusCodeOk()
            Dim result = _browser.Get("/trees/abc", Sub(x)
                                                        x.HttpRequest()
                                                    End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithId2ReturnsWebpagePlantWithId2()
            Dim result = _browser.Get("/trees/2", Sub(x)
                                                      x.HttpRequest()
                                                  End Sub)
            Assert.AreEqual("2", result.BodyAsXml.Descendants("td")(1).Value)
        End Sub

        <Test>
        Public Sub IfPlantAddReturnsStatusCodeOk()
            Dim result = _browser.Get("/trees/add/", Sub(x)
                                                         x.HttpRequest()
                                                     End Sub)
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantAddReturnsBody()
            Dim result = _browser.Get("/trees/add/", Sub(x)
                                                         x.HttpRequest()
                                                     End Sub)

            Assert.AreEqual("Add tree page", result.BodyAsXml...<title>.Value())
        End Sub

        <Test>
        Public Sub IfPlantWithId10ReturnsStatusCodeNotFound()
            Dim result = _browser.Get("/trees/10", Sub(x)
                                                       x.HttpRequest()
                                                   End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithIdReturnsStatusCodeNotFound()
            Dim result = _browser.Get("/trees/-1", Sub(x)
                                                       x.HttpRequest()
                                                   End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub
    End Class
End Namespace