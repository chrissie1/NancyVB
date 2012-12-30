using System;
using System.IO;
using EasyHttp.Http;

namespace NancyDemo.Csharp.Easyhttp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            http.Request.ParametersAsSegments = true;
            var trees = http.Get("http://localhost:65367/trees");
            foreach (var t in trees.DynamicBody.Trees)
            {
                Console.WriteLine(t.Id);
                Console.WriteLine(t.Genus);
            }
            var result = http.Get("http://localhost:65367/trees/1");
            var tree = result.DynamicBody;
            Console.WriteLine(tree.Id);
            Console.WriteLine(tree.Genus);
            result = http.Get("http://localhost:65367/trees", new { Id = 2 });
            tree = result.DynamicBody;
            Console.WriteLine(tree.Id);
            Console.WriteLine(tree.Genus);
            http.Request.Accept = "application/pdf";
            http.Request.ParametersAsSegments = true;
            const string filename = "e:\\temp\\Test.pdf";
            if (File.Exists(filename)) File.Delete(filename);
            Console.WriteLine("Get pdf");
            http.GetAsFile("http://localhost:65367/trees/1", filename);
            Console.WriteLine("Pdf created");
            Console.ReadLine();
        }
    }
}
