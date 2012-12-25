using Nancy.ModelBinding;
using Nancy;
using NancyDemo.Csharp.Model;
using NancyDemo.Csharp.Services;

namespace NancyDemo.Csharp.Modules
{
    public class TreesModule : NancyModule
    {

        public TreesModule(TreeService treeService)
        {
            Get["/trees"] = parameters => Negotiate.WithModel(new TreesModel() { Trees = treeService.AllTrees() });
            Get["/trees/{Id}"] = parameters =>
                {
                    int result;
                    var isInteger = int.TryParse(parameters.id, out result);
                    var tree = treeService.FindById(result);
                    if(isInteger && tree != null)
                    {
                        return Negotiate.WithModel(tree);
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }
                };
            Get["/trees/add/"] = parameters => View["AddTree.cshtml", new TreeModel()];
            Post["/trees/add/"] = parameters =>
            {
                var tree = this.Bind<TreeModel>();
                treeService.Add(tree);
                return Response.AsRedirect("/trees");
            };
        }
    }
}
