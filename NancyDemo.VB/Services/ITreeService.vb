Imports NancyDemo.VB.Model

Namespace Services
    Public interface ITreeService
        Function AllTrees() As IList(Of TreeModel)
        Function FindById(ByVal id As Integer) As TreeModel
    end interface
End NameSpace