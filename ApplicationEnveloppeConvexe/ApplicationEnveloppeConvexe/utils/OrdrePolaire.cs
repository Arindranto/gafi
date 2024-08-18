using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;

namespace ApplicationEnveloppeConvexe.Utils
{
    public class OrdrePolaire : IComparer<Drawing.Point>
    {
        Drawing.Point origin;
        public OrdrePolaire(Drawing.Point origin)
        {
            this.origin = origin;
        }
        public int Compare(Drawing.Point x, Drawing.Point y)
        {
            Vector2 ox = PointUtils.VecteurAvecOrigine(origin, x);
            Vector2 oy = PointUtils.VecteurAvecOrigine(origin, y);
            float det = VecteurUtils.Det(ox, oy);
            if (det > 0 || det == 0 && ox != oy)
            {
                return -1;  // x avant y
            }
            return 1;   // x après y
        }
    }
}
