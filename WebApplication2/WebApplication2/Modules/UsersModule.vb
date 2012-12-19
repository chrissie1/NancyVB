Imports WebApplication2.Model
Imports Nancy
Imports Nancy.Security
Imports WebApplication2.Services

Namespace Modules

    Public Class UsersModule
        Inherits NancyModule

        Public Sub New(userService As UserService)
            Me.RequiresAuthentication()
            MyBase.Get("/users") = Function(parameters)
                                       Return View(New UsersModel() With {.Users = userService.GetUsers()})
                                   End Function
            MyBase.Get("/users/{Id}") = Function(parameters)
                                            Dim result As Guid
                                            Dim isInteger = Guid.TryParse(parameters.id, result)
                                            Dim user = userService.GetById(result)
                                            If isInteger AndAlso user IsNot Nothing Then
                                                Return View(user)
                                            Else
                                                Return HttpStatusCode.NotFound
                                            End If
                                        End Function

        End Sub
    End Class
End Namespace