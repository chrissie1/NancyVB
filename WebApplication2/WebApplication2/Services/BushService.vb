Imports WebApplication2.Model

Namespace Services
    Public Class BushService
        Implements IBushService

        Private ReadOnly _bushes As IList(Of BushModel)

        Public Sub New()
            _bushes = New List(Of BushModel)
            _bushes.Add(New BushModel() With {.Id = 1, .Genus = "Forsythia"})
            _bushes.Add(New BushModel() With {.Id = 2, .Genus = "Hydrangea"})
            _bushes.Add(New BushModel() With {.Id = 3, .Genus = "Buddleia"})
        End Sub

        Public Function AllBushes() As IList(Of BushModel) Implements IBushService.AllBushes
            Return _bushes
        End Function

        Public Function FindById(ByVal id As Integer) As BushModel Implements IBushService.FindById
            Return _bushes.SingleOrDefault(Function(x) x.Id = id)
        End Function

        Public Sub add(ByVal bushModel As BushModel) Implements IBushService.add
            _bushes.Add(bushModel)
        End Sub

    End Class
End Namespace