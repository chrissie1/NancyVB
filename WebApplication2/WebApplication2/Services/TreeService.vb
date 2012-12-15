Imports WebApplication2.Model

Namespace Services
    Public Class TreeService
        
        Private ReadOnly _trees As IList(Of TreeModel)

        Public Sub New()
            _trees = New List(Of TreeModel)
            _trees.Add(New TreeModel() With {.Id = 1, .Genus = "Fagus"})
            _trees.Add(New TreeModel() With {.Id = 2, .Genus = "Quercus"})
            _trees.Add(New TreeModel() With {.Id = 3, .Genus = "Betula"})
        End Sub

        Public Function AllTrees() As IList(Of TreeModel)
            Return _trees
        End Function

        Public Function FindById(ByVal id As Integer) As TreeModel
            Return _trees.SingleOrDefault(Function(x) x.Id = id)
        End Function

        Public Sub Add(ByVal treeModel As TreeModel)
            _trees.Add(treeModel)
        End Sub
    End Class
End Namespace