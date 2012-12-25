using System;
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
            var trees = http.Get("http://localhost:55360/trees");
            foreach(var t in trees.DynamicBody.Trees)
            {
                Console.WriteLine(t.Id);
                Console.WriteLine(t.Genus);
            }
            var result = http.Get("http://localhost:55360/trees/1");
            var tree = result.DynamicBody;
            Console.WriteLine(tree.Id);
            Console.WriteLine(tree.Genus);
            result = http.Get("http://localhost:55360/trees", new { Id = 2 });
            tree = result.DynamicBody;
            Console.WriteLine(tree.Id);
            Console.WriteLine(tree.Genus);
            
            Console.ReadLine();
        }
    }
}
