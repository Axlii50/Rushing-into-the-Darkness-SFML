using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes
{
    class Functions
    {
        public static float CalculateDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Round(Math.Sqrt(Math.Pow((x1 - x2) * 1, 2) + Math.Pow((y1 - y2) * 1, 2)), 0);
        }
    }
}
