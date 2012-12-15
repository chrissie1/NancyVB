using Nancy;

namespace WebApplication1.Modules
{
    public  class MainModule : NancyModule
    {

        public  MainModule()
        {
            Get["/"] = parameters => View["Default.cshtml"];
        }
    }
}
