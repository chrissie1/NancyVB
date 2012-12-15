using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class TreeService
    {
        private readonly IList<TreeModel> _trees;

        public TreeService()
        {
            _trees = new List<TreeModel>();
            _trees.Add(new TreeModel() {Id = 1, Genus = "Fagus"});
            _trees.Add(new TreeModel() {Id = 2, Genus = "Quercus"});
            _trees.Add(new TreeModel() {Id = 3, Genus = "Betula"});
        }

        public IList<TreeModel> AllTrees()
        {
            return _trees;
        }

        public TreeModel FindById(int id)
        {
            return _trees.SingleOrDefault(x=> x.Id == id);
        }

        public void Add(TreeModel treeModel)
        {
            _trees.Add(treeModel);
        }
    }
}
