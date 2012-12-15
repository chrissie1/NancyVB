Imports Nancy.Hosting.Aspnet
Imports Nancy
Imports Nancy.TinyIoc
Imports WebApplication2.Services

Public Class MyBootStrapper
    Inherits DefaultNancyBootstrapper

    Protected Overrides Sub ConfigureApplicationContainer(container As TinyIoCContainer)
        container.Register(Of BushService).AsSingleton()
        container.Register(Of TreeService).AsSingleton()
    End Sub
End Class
