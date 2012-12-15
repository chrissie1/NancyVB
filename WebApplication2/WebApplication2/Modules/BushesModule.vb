Imports Nancy.ModelBinding
Imports WebApplication2.Services
Imports WebApplication2.Model
Imports Nancy

Namespace Modules

    Public Class BushesModule
        Inherits NancyModule

        Public Sub New(ByVal bushService As BushService)
            MyBase.Get("/bushes") = Function(parameters)
                                        Return View(New BushesModel() With {.Bushes = bushService.AllBushes()})

                                    End Function
            MyBase.Get("/bushes/{Id}") = Function(parameters)
                                             Dim result As Integer
                                             Dim isInteger = Integer.TryParse(parameters.id, result)
                                             Dim bush = bushService.FindById(result)
                                             If isInteger AndAlso bush IsNot Nothing Then
                                                 Return View(bush)
                                             Else
                                                 Return HttpStatusCode.NotFound
                                             End If
                                         End Function
            MyBase.Get("/bushes/add/") = Function(parameters)
                                             Return View("AddBush.vbhtml", New BushModel)
                                         End Function
            MyBase.Post("/bushes/add/") = Function(parameters)
                                              Dim bush = Me.Bind(Of BushModel)()
                                              bushService.add(bush)
                                              Return Response.AsRedirect("/bushes")
                                          End Function
        End Sub

    End Class
End Namespace