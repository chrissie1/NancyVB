Option Strict Off

Imports System.Dynamic
Imports Nancy.Authentication.Forms
Imports Nancy.ModelBinding
Imports Nancy
Imports WebApplication2.Services

Namespace Modules

    Public Class LoginModule
        Inherits NancyModule

        Public Sub New(ByVal userService As UserService)
            MyBase.Get("/login") = Function(parameters)
                                       Return View("login.vbhtml")
                                   End Function
            MyBase.Post("/login") = Function(parameters)
                                        Dim loginParams = Me.Bind(Of LoginParams)()
                                        Dim user = userService.AuthenticateUser(loginParams.Username, loginParams.Password)
                                        If user Is Nothing Then
                                            Return "Your username and password were incorrect please enter a correct one."
                                        End If
                                        Return Me.LoginAndRedirect(user.Id)
                                    End Function
            MyBase.Get("/logout") = Function(parameters)
                                        Return Me.LogoutAndRedirect("~/")
                                    End Function
        End Sub
    End Class

    Public Class LoginParams
        Public Property Username As String
        Public Property Password As String
    End Class
End Namespace