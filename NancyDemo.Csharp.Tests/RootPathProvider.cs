using System;
using System.IO;
using System.Linq;
using Nancy;

namespace NancyDemo.Csharp.Tests
{
    public class RootPathProvider: IRootPathProvider
    {
        private static String _cachedRootPath;

        public String GetRootPath()
        {
            if (!String.IsNullOrEmpty(_cachedRootPath)) return _cachedRootPath;
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            currentDirectory = currentDirectory.Parent.Parent.Parent.GetDirectories()[1];
            var rootPathFound = false;
            while (!rootPathFound)
            {
                var directoriesContainingViewFolder = currentDirectory.GetDirectories("Views", SearchOption.AllDirectories);
                if(directoriesContainingViewFolder.Any())
                {
                    _cachedRootPath = directoriesContainingViewFolder.First().FullName;
                    rootPathFound = true;
                }
                currentDirectory = currentDirectory.Parent;
            }
            return _cachedRootPath;
        }

    }
}
