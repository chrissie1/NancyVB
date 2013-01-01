using System.Collections.Generic;
using System.Linq;
using NancyDemo.Csharp.Model;

namespace NancyDemo.Csharp.Services
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
            _trees.Add(new TreeModel() { Id = 4, Genus = "Fagus" });
            _trees.Add(new TreeModel() { Id = 5, Genus = "Quercus" });
            _trees.Add(new TreeModel() { Id = 6, Genus = "Betula" });
            _trees.Add(new TreeModel() { Id = 7, Genus = "Fagus" });
            _trees.Add(new TreeModel() { Id = 8, Genus = "Quercus" });
            _trees.Add(new TreeModel() { Id = 9, Genus = "Betula" });
            _trees.Add(new TreeModel() { Id = 10, Genus = "Fagus" });
            _trees.Add(new TreeModel() { Id = 11, Genus = "Quercus" });
            _trees.Add(new TreeModel() { Id = 12, Genus = "Betula" });
            _trees.Add(new TreeModel() { Id = 13, Genus = "Fagus" });
            _trees.Add(new TreeModel() { Id = 14, Genus = "Quercus" });
            _trees.Add(new TreeModel() { Id = 15, Genus = "Betula" });
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
