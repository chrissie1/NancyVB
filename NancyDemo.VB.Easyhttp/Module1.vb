Imports System.Net
Imports EasyHttp.Http

Module Module1

    Sub Main()
        Dim http = New HttpClient()
        http.Request.Accept = HttpContentTypes.ApplicationJson
        Dim trees = http.Get("http://localhost:55360/trees")
        For Each t In trees.DynamicBody.Trees
            Console.WriteLine(t.Id)
            Console.WriteLine(t.Genus)
        Next
        Dim result = http.Get("http://localhost:55360/trees/1")
        Dim tree = result.DynamicBody
        Console.WriteLine(tree.Id)
        Console.WriteLine(tree.Genus)
        Console.ReadLine()
    End Sub

End Module
