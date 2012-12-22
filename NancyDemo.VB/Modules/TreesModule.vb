Imports NancyDemo.VB.Model
Imports Nancy.ModelBinding
Imports NancyDemo.VB.Services
Imports Nancy

Namespace Modules

    Public Class TreesModule
        Inherits NancyModule

        Public Sub New(ByVal treeService As TreeService)
            MyBase.Get("/trees") = Function(parameters)
                                       Return Negotiate.WithModel(New TreesModel() With {.Trees = treeService.AllTrees()})
                                   End Function
            MyBase.Get("/trees/{Id}") = Function(parameters)
                                            Dim result As Integer
                                            Dim isInteger = Integer.TryParse(parameters.id, result)
                                            Dim tree = treeService.FindById(result)
                                            If isInteger AndAlso tree IsNot Nothing Then
                                                Return Negotiate.WithModel(tree)
                                            Else
                                                Return HttpStatusCode.NotFound
                                            End If
                                        End Function
            MyBase.Get("/trees/add/") = Function(parameters)
                                            Return View("AddTree.vbhtml", New TreeModel)
                                        End Function
            Post("/trees/add/") = Function(parameters)
                                      Dim tree = Bind(Of TreeModel)()
                                      treeService.Add(tree)
                                      Return Response.AsRedirect("/trees")
                                  End Function

        End Sub

    End Class
End Namespace