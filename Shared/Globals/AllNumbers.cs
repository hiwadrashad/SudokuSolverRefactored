using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Globals
{
    public static class AllNumbers
    {
        public static List<int> GetAllNumbers
        {
            get { return Enumerable.Range(1, 9).ToList(); }
        }
    }
}
