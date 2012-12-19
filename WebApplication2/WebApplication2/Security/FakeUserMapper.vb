Imports Nancy.Authentication.Forms
Imports WebApplication2.Services

Namespace Security
    Public Class FakeUserMapper
        Implements IUserMapper

        Private ReadOnly _userService As UserService

        Public Sub New(userService As UserService)
            _userService = userService
        End Sub


        Public Function GetUserFromIdentifier(ByVal identifier As Guid, ByVal context As Nancy.NancyContext) As Nancy.Security.IUserIdentity Implements IUserMapper.GetUserFromIdentifier
            Dim user = _userService.GetById(identifier)
            Return New AuthenticatedUser() With
            {
                .UserName = user.Name,
                .Claims = user.Claims
            }
        End Function

    End Class
End Namespace