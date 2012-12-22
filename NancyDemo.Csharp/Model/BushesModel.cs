using System.Collections.Generic;

namespace NancyDemo.Csharp.Model
{
    public  class BushesModel
    {
        public  IList<BushModel> Bushes { get; set; }
        public  int NumberOfBushes
        {
            get { return Bushes.Count; }
        }
    }
}
