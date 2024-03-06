using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EnveloppeConvexe
{
    internal class OrdrePolaire : IComparer<Point>
    {
        Point origin;
        public OrdrePolaire(Point origin)
        {
            this.origin = origin;
        }
        public int Compare(Point x, Point y)
        {
            Vector2 ox = x.VecteurAvecOrigine(origin);
            Vector2 oy = y.VecteurAvecOrigine(origin);
            float det = VecteurUtils.Det(ox, oy);
            if (det > 0 || det == 0 && ox != oy)
            {
                return -1;  // x avant y
            }
            return 1;   // x après y
        }
    }
}
