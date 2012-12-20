Imports FakeItEasy
Imports System.IO
Imports Nancy.Testing.Fakes
Imports Nancy.Authentication.Forms
Imports WebApplication2.Services
Imports WebApplication2.Security
Imports WebApplication2.Modules
Imports Nancy
Imports NUnit.Framework
Imports Nancy.Testing
Imports Nancy.ViewEngines.Razor

Namespace Tests

    <TestFixture>
    Public Class TestUsersModule

        Private _notLoggedInBrowser As Browser
        Private _loggedInBrowserResponse As BrowserResponse

        <SetUp()>
        Public Sub FixtureSetup()
            Dim formsAuthenticationConfiguration = New FormsAuthenticationConfiguration() With
                        {
                            .RedirectUrl = "~/login",
                            .UserMapper = New FakeUserMapper(New UserService())
                        }
            Dim configuration = A.Fake(Of IRazorConfiguration)()
            Dim bootstrapper = New ConfigurableBootstrapper(Sub(config)
                                                                config.Module(Of UsersModule)()
                                                                config.Module(Of LoginModule)()
                                                                config.ViewEngine(New RazorViewEngine(configuration))
                                                            End Sub)
            Dim bootstrapper2 = New ConfigurableBootstrapper(Sub(config)
                                                                 config.Module(Of UsersModule)()
                                                                 config.Module(Of LoginModule)()
                                                                 config.ViewEngine(New RazorViewEngine(configuration))
                                                                 config.RequestStartup(Sub(x, pipelines, z)
                                                                                           FormsAuthentication.Enable(pipelines, formsAuthenticationConfiguration)
                                                                                       End Sub)
                                                             End Sub)
            _notLoggedInBrowser = New Browser(bootstrapper)
            _loggedInBrowserResponse = New Browser(bootstrapper2).Post("/login", Sub(x)
                                                                                     x.HttpRequest()
                                                                                     x.FormValue("Username", "Chris1")
                                                                                     x.FormValue("Password", "123")
                                                                                 End Sub)
        End Sub

        <Test>
        Public Sub IfPlantsRouteReturnsStatusCodeUnAuthorized()
            Dim result = _notLoggedInBrowser.Get("/users", Sub(x)
                                                               x.HttpRequest()
                                                           End Sub)
            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithId1RouteReturnsStatusCodeUnAuthorized()
            Dim result = _notLoggedInBrowser.Get("/users/1", Sub(x)
                                                                 x.HttpRequest()
                                                             End Sub)
            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfUserssAuthenticatedReturnsStatusCodeOk()
            Dim result = _loggedInBrowserResponse.Then.Get("/users", Sub(x)
                                                                         x.HttpRequest()
                                                                     End Sub)
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithIdabcRouteReturnsStatusCodeOk()
            Dim result = _loggedInBrowserResponse.Then.Get("/users/abc", Sub(x)
                                                                             x.HttpRequest()
                                                                         End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithId2ReturnsStatusOk()
            Dim result = _loggedInBrowserResponse.Then.Get("/users/00000000-0000-0000-0000-000000000004", Sub(x)
                                                                                                              x.HttpRequest()
                                                                                                          End Sub)
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithId2ReturnsWebpagePlantWithId2()
            Dim result = _loggedInBrowserResponse.Then.Get("/users/00000000-0000-0000-0000-000000000004", Sub(x)
                                                                                                              x.HttpRequest()
                                                                                                          End Sub)
            Assert.AreEqual("00000000-0000-0000-0000-000000000004", result.BodyAsXml.Descendants("td")(1).Value)
        End Sub

        <Test>
        Public Sub IfPlantWithId10ReturnsStatusCodeNotFound()
            Dim result = _loggedInBrowserResponse.Then.Get("/users/10", Sub(x)
                                                                            x.HttpRequest()
                                                                        End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub

        <Test>
        Public Sub IfPlantWithIdReturnsStatusCodeNotFound()
            Dim result = _loggedInBrowserResponse.Then.Get("/users/-1", Sub(x)
                                                                            x.HttpRequest()
                                                                        End Sub)
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode)
        End Sub
    End Class

End Namespace