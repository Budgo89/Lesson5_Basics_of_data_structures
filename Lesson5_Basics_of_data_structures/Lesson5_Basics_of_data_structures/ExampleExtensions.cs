using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_Basics_of_data_structures
{
    public static class ExampleExtensions
    {
        public static int CharCount(this string str)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {               
                    counter++;
            }
            return counter;
        }
    }
}
