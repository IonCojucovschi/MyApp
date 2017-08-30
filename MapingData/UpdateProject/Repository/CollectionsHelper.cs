using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateProject.Repository
{
    public static class CollectionsHelper
    {
        public static void PrintToConsole<T>(this IEnumerable<T> list) where T : class
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
