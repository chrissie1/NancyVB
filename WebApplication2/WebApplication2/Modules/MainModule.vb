Imports Nancy

Namespace Modules
    Public Class MainModule
        Inherits NancyModule

        Public Sub New()
            MyBase.Get("/") = Function()
                                  Return View("Default.vbhtml")
                              End Function
        End Sub

    End Class
End Namespace