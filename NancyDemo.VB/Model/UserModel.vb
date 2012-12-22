Namespace Model
    Public Class UserModel
        Public Property Id As Guid
        Public Property Name As String
        Public Property Claims As IEnumerable(Of String)
        Public Property Password As String

        Public Sub New()
            Claims = New List(Of String)()
        End Sub
    End Class
End Namespace