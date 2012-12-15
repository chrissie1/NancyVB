using System.IO
using Nancy

public class RootPathProvider
    Implements IRootPathProvider

    private Shared _cachedRootPath As String

    public Function GetRootPath() As String Implements IRootPathProvider.GetRootPath
        If Not String.IsNullOrEmpty(_cachedRootPath) Then Return _cachedRootPath
        var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory)
        currentDirectory = currentDirectory.Parent.Parent.Parent.GetDirectories()(1)
        var rootPathFound = False
        While Not rootPathFound
            var directoriesContainingViewFolder = currentDirectory.GetDirectories("Views", SearchOption.AllDirectories)
            If directoriesContainingViewFolder.Any() Then
                _cachedRootPath = directoriesContainingViewFolder.First().FullName
                rootPathFound = True
            End If
            currentDirectory = currentDirectory.Parent
        End While
        Return _cachedRootPath
    End Function

    public Function Equals1(obj As Object) As Boolean Implements IHideObjectMembers.Equals

    End Function

    public Function GetHashCode1() As Integer Implements IHideObjectMembers.GetHashCode

    End Function

    public Function GetType1() As Type Implements IHideObjectMembers.GetType

    End Function

    public Function ToString1() As String Implements IHideObjectMembers.ToString

    End Function
}
