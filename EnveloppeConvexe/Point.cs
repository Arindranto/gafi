using System.Numerics;

namespace EnveloppeConvexe
{
    internal class Point
    {
        public float X { get; }
        public float Y { get; }
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point Read()
        {
            Console.Write("x: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("y: ");
            float y = float.Parse(Console.ReadLine());
            return new Point(x, y);
        }

        public static float ProduitVectoriel(Point a, Point b, Point c)
        {
            Vector2 ab = b.VecteurAvecOrigine(a);
            Vector2 ac = c.VecteurAvecOrigine(a);
            return VecteurUtils.Det(ab, ac);
            // return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);   // x1*y2 - y1*x2
        }

        public Vector2 VecteurAvecOrigine(Point a)
        {
            return new Vector2(this.X - a.X, this.Y - a.Y);
        }

        public bool EstADroite(Point a, Point b)
        {
            return ProduitVectoriel(a, b, this) < 0;
        }

        public override string ToString()
        {
            return $"[{this.X}, {this.Y}]";
        }
    }
}
