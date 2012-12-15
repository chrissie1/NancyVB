Imports System.IO
Imports Nancy

Public Class RootPathProvider
    Implements IRootPathProvider

    Private Shared _cachedRootPath As String

    Public Function GetRootPath() As String Implements IRootPathProvider.GetRootPath
        If Not String.IsNullOrEmpty(_cachedRootPath) Then Return _cachedRootPath
        Dim currentDirectory = New DirectoryInfo(Environment.CurrentDirectory)
        Dim rootPathFound = False
        While Not rootPathFound
            Dim directoriesContainingViewFolder = currentDirectory.GetDirectories("Views", SearchOption.AllDirectories)
            If directoriesContainingViewFolder.Any() Then
                _cachedRootPath = directoriesContainingViewFolder.First().FullName
                rootPathFound = True
            End If
            currentDirectory = currentDirectory.Parent
        End While
        Return _cachedRootPath
    End Function

    Public Function Equals1(obj As Object) As Boolean Implements IHideObjectMembers.Equals

    End Function

    Public Function GetHashCode1() As Integer Implements IHideObjectMembers.GetHashCode

    End Function

    Public Function GetType1() As Type Implements IHideObjectMembers.GetType

    End Function

    Public Function ToString1() As String Implements IHideObjectMembers.ToString

    End Function
End Class