using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Models
{
    static class DestinationOptions
    {
        public readonly static Dictionary<int,string> Dictionary;

        static DestinationOptions()
        {
            Dictionary = new Dictionary<int, string>()
            {
                { 0, "Denver" },
                {1, "San Diego" },
                {2, "Seattle" },
                { 3,"Fort Lauderdale" },
                {4, "Galway" },
                {5, "England" }
            };
        }
        
    }
}
