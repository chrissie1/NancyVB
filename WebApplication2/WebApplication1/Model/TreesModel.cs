using System.Collections.Generic;

namespace WebApplication1.Model
{
    public  class TreesModel
    {
        public  IList<TreeModel> Trees { get; set; }
        public  int NumberOfTrees
        {
            get { return Trees.Count; }
        }
    }
}
