Namespace Model
    Public Class TreesModel
        Public Property Trees As IList(Of TreeModel)
        Public ReadOnly Property NumberOfTrees As Integer
            Get
                Return Trees.Count
            End Get
        End Property
    End Class
End Namespace