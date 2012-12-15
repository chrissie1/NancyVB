using WebApplication1.Services;
using WebApplication1.Model;
using Nancy;

namespace WebApplication1.Modules
{
    public class TreesModule : NancyModule
    {

        public TreesModule(TreeService treeService)
        {
            Get["/trees"] = parameters => View[new TreesModel() {Trees = treeService.AllTrees()}];
            Get["/trees/{Id}"] = parameters =>
                {
                    int result;
                    var isInteger = int.TryParse(parameters.id, out result);
                    var tree = treeService.FindById(result);
                    if (isInteger && tree != null)
                    {
                        return View[tree];
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }
                };
        }
    }
}
