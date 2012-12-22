Imports Nancy.Bootstrapper
Imports Nancy.Authentication.Forms
Imports Nancy
Imports Nancy.TinyIoc
Imports NancyDemo.VB.Services
Imports NancyDemo.VB.Security

Public Class MyBootStrapper
    Inherits DefaultNancyBootstrapper

    Protected Overrides Sub ConfigureApplicationContainer(container As TinyIoCContainer)
        container.Register(Of BushService).AsSingleton()
        container.Register(Of TreeService).AsSingleton()
        container.Register(Of UserService).AsSingleton()
    End Sub

    Protected Overrides Sub ConfigureRequestContainer(container As TinyIoCContainer, context As NancyContext)
        MyBase.ConfigureRequestContainer(container, context)
        container.Register(Of IUserMapper, FakeUserMapper)()
    End Sub

    Protected Overrides Sub RequestStartup(container As TinyIoCContainer, pipelines As IPipelines, context As NancyContext)
        Dim formsAuthConfiguration = New FormsAuthenticationConfiguration With
        {
            .RedirectUrl = "~/login",
            .UserMapper = container.Resolve(Of IUserMapper)()
        }
        FormsAuthentication.Enable(pipelines, formsAuthConfiguration)
    End Sub
End Class
