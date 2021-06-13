using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan
{
    public static class Extensions
    {
        private const double Epsilon = 1e-10;
        // private const double Epsilon = 1;
        public static bool IsZero(this double d)
        {
            return Math.Abs(d) < Epsilon;
        }
    }
}
