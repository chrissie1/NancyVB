Imports NancyDemo.VB.Model

Namespace Services
    Public Class UserService

        Private ReadOnly _users As IList(Of UserModel)

        Public Sub New()
            _users = New List(Of UserModel)
            _users.Add(New UserModel With {.Id = New Guid("00000000000000000000000000000004"), .Name = "Chris1", .Password = "123"})
            _users.Add(New UserModel With {.Id = New Guid("00000000000000000000000000000001"), .Name = "Chris2", .Password = "123"})
            _users.Add(New UserModel With {.Id = New Guid("00000000000000000000000000000002"), .Name = "Chris3", .Password = "123"})
            _users.Add(New UserModel With {.Id = New Guid("00000000000000000000000000000003"), .Name = "Chris4", .Password = "123"})
        End Sub

        Public Function GetUsers() As IList(Of UserModel)
            Return _users
        End Function

        Public Function AuthenticateUser(ByVal username As String, ByVal password As String)
            Dim user = _users.SingleOrDefault(Function(userModel) userModel.Name = username)
            If user IsNot Nothing AndAlso Not user.Password.Equals(password) Then
                Return Nothing
            End If
            Return user
        End Function

        Public Function GetById(ByVal identifier As Guid) As UserModel
            Return _users.SingleOrDefault(Function(userModel) userModel.Id = identifier)
        End Function
    End Class
End Namespace