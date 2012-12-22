Imports NancyDemo.VB.Model

Namespace Services
    Public interface IBushService
        Function AllBushes() As IList(Of BushModel)
        Function FindById(ByVal id As Integer) As BushModel
        Sub Add(ByVal bushModel As BushModel)
    end interface
End NameSpace