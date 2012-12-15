using Nancy.ModelBinding;
using WebApplication1.Services;
using WebApplication1.Model;
using Nancy;

namespace WebApplication1.Modules
{
    public class BushesModule : NancyModule
    {
        public BushesModule(BushService bushService)
        {
            Get["/bushes"] = parameters => View[new BushesModel() {Bushes = bushService.AllBushes()}];
            Get["/bushes/{Id}"] = parameters =>
                {
                    var result = 0;
                    var isInteger = int.TryParse(parameters.id, out result);
                    var bush = bushService.FindById(result);
                    if (isInteger && bush != null)
                    {
                        return View[bush];
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }
                };
            Get["/bushes/add/"] = parameters => View["AddBush.cshtml", new BushModel()];
            Post["/bushes/add/"] = parameters =>
                {
                    var bush = this.Bind<BushModel>();
                    bushService.Add(bush);
                    return Response.AsRedirect("/bushes");
                };
        }

    }
}
