using Nancy;

namespace NancyDemo.Csharp.Modules
{
    public  class MainModule : NancyModule
    {

        public  MainModule()
        {
            Get["/"] = parameters => View["Default.cshtml"];
        }
    }
}
