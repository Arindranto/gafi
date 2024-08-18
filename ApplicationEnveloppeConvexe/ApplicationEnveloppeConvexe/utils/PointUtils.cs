using System.Numerics;
using Drawing = System.Drawing;

namespace ApplicationEnveloppeConvexe.Utils
{
    public static class PointUtils
    {
        public static float ProduitVectoriel(Drawing.Point a, Drawing.Point b, Drawing.Point c)
        {
            Vector2 ab = VecteurAvecOrigine(a, b);
            Vector2 ac = VecteurAvecOrigine(a, c);
            return VecteurUtils.Det(ab, ac);
        }
        public static float ProduitVectoriel(Components.Point a, Components.Point b, Components.Point c)
        {
            return ProduitVectoriel(a.Coord, b.Coord, c.Coord);
            // return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);   // x1*y2 - y1*x2
        }

        public static Vector2 VecteurAvecOrigine(Drawing.Point a, Drawing.Point b)
        {
            return new Vector2(b.X - a.X, b.Y - a.Y);
        }

        public static bool EstADroite(Drawing.Point a, Drawing.Point b, Drawing.Point c)
        {
            // Si c est a droite de AB
            return ProduitVectoriel(a, b, c) < 0;
        }
    }
}
