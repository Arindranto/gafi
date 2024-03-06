using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EnveloppeConvexe
{
    internal class VecteurUtils
    {
        public static float Det(Vector2 v1, Vector2 v2)
        {
            return (v1.X * v2.Y - v1.Y * v2.X);
        }
    }
}
