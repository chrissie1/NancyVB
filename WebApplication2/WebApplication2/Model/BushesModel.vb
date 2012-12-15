Namespace Model
    Public Class BushesModel
        Public Property Bushes As IList(Of BushModel)
        Public ReadOnly Property NumberOfBushes As Integer
            Get
                Return Bushes.Count
            End Get
        End Property
    End Class
End Namespace