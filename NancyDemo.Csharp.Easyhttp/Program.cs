using System;
using System.IO;
using EasyHttp.Http;
using ServiceStack.Text;

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
            Console.WriteLine(trees.StaticBody<Object>().SerializeToString());
            var result = http.Get("http://localhost:65367/trees/1");
            Console.WriteLine(result.StaticBody<Object>().SerializeToString());
            result = http.Get("http://localhost:65367/trees", new { Id = 2 });
            var tree2 = result.DynamicBody;
            Console.WriteLine(tree2.Id);
            Console.WriteLine(tree2.Genus);
            http.Request.Accept = "application/pdf";
            http.Request.ParametersAsSegments = true;
            const string filename = "e:\\temp\\Test.pdf";
            const string filename2 = "e:\\temp\\Test2.pdf";
            if (File.Exists(filename)) File.Delete(filename);
            if (File.Exists(filename2)) File.Delete(filename2);
            Console.WriteLine("Get pdf of 1 tree");
            http.GetAsFile("http://localhost:65367/trees/1", filename);
            Console.WriteLine("Pdf created");
            Console.WriteLine("Get pdf of all trees");
            http.GetAsFile("http://localhost:65367/trees", filename2);
            Console.WriteLine("Pdf created");
            Console.ReadLine();
        }
    }
}
