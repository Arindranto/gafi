using System.Linq;

namespace EnveloppeConvexe
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            Console.Write("Entrez le nombre de point: ");
            int taille = int.Parse(Console.ReadLine()); 
            Point[] p = new Point[taille];

            for (int i = 0; i < taille; i++)
            {
                Console.WriteLine($"**** Point {i+1} *****");
                p[i] = Point.Read();
            } */
            Point[] p = TestData.GetDatas();

            Point[] enveloppeConvexe = Graham(p);
            foreach (Point point in enveloppeConvexe)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine("Appuyer sur une touche pour terminer le programme...");
            Console.ReadKey();
        }

        public static Point[] Graham(Point[] p)
        {
            if (p.Length == 0)
            {
                return new Point[0];
            }

            Point pmin = p.MinBy(a => a.Y);
            p = new Point[1] { pmin }.Concat(Array.FindAll(p, a => a != pmin).OrderBy(a => a, new OrdrePolaire(pmin)).ToArray()).ToArray();   // Le reste des point trié par ordre polaire
            Stack<Point> stack = new Stack<Point>();

            /*
                NB: Un Stack en C# a ses éléments triés du plus récent au plus ancien soit:
                    * ElementAt(0) = Peek()
                    * ElementAt(1): l'avant-dernier élément le plus récent
                    * ...
                    * ElementAt(stack.Count - 1): l'élément le plus ancien
             */

            stack.Push(p[0]);
            stack.Push(p[1]);
            stack.Push(p[2]);

            for (int i = 3; i < p.Length; i++)
            {
                Point beforeLast = stack.ElementAt(1);
                Point last = stack.Peek();
                while (stack.Count > 2 && p[i].EstADroite(beforeLast, last))
                {
                    Point popped = stack.Pop();
                    beforeLast = stack.ElementAt(1);
                    last = stack.Peek();
                }
                stack.Push(p[i]);
            }
            return stack.ToArray();
        }
    }
}
