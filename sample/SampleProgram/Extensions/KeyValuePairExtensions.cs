using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgram.Extensions
{
    public static class KeyValuePairExtensions
    {
        public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> pair, out T1 a, out T2 b)
        {
            a = pair.Key;
            b = pair.Value;
        }
    }
}
