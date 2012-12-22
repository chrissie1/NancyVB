using System.Collections.Generic;

namespace NancyDemo.Csharp.Model
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
