using System.Collections.Generic;
using System.Linq;
using NancyDemo.Csharp.Model;

namespace NancyDemo.Csharp.Services
{
    public class BushService
    {

        private readonly IList<BushModel> _bushes;

        public BushService()
        {
            _bushes = new List<BushModel>();
            _bushes.Add(new BushModel() {Id = 1, Genus = "Forsythia"});
            _bushes.Add(new BushModel() {Id = 2, Genus = "Hydrangea"});
            _bushes.Add(new BushModel() {Id = 3, Genus = "Buddleia"});
        }

        public IList<BushModel> AllBushes()
        {
            return _bushes;
        }

        public  BushModel FindById(int id)
        {
            return _bushes.SingleOrDefault(x => x.Id == id);
        }

        public void Add(BushModel bushModel)
        {
            _bushes.Add(bushModel);
        }

    }
}
