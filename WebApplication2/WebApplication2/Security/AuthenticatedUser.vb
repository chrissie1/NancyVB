Imports Nancy.Security

Namespace Security

    Public Class AuthenticatedUser
        Implements IUserIdentity

        Public Property UserName() As String Implements IUserIdentity.UserName
        Public Property Claims() As IEnumerable(Of String) Implements IUserIdentity.Claims
    End Class
End Namespace