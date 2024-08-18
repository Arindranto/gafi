using Drawing = System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.CodeDom;
using ApplicationEnveloppeConvexe.Utils;

namespace ApplicationEnveloppeConvexe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBNbr.Text, out int num))
            {
                MainCanvas.Children.RemoveRange(3, MainCanvas.Children.Count - 3);
                
                Random rnd = new Random();

                for (int i = 0; i < num; i++)
                {
                    int x = rnd.Next(10, (int)Math.Floor(MainCanvas.ActualWidth) - 10);
                    int y = rnd.Next(10, (int)Math.Floor(MainCanvas.ActualHeight) - 10);
                    Components.Point point = new Components.Point(x, y);
                    MainCanvas.Children.Add(point);
                }

                TracerEnveloppeConvexe();
            }
            else
            {
                MessageBox.Show("Nombre de Point invalide", "Enveloppe Convexe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static Drawing.Point[] Graham(Drawing.Point[] p)
        {
            if (p.Length == 0)
            {
                return new Drawing.Point[0];
            }

            Drawing.Point pmin = p.MinBy(a => a.Y); // Ordonné Minimum
            p = new Drawing.Point[1] { pmin }.Concat(Array.FindAll(p, a => a != pmin).OrderBy(a => a, new OrdrePolaire(pmin)).ToArray()).ToArray();   // Le reste des point trié par ordre polaire
            Stack<Drawing.Point> stack = new Stack<Drawing.Point>();

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
                Drawing.Point beforeLast = stack.ElementAt(1);
                Drawing.Point last = stack.Peek();
                while (stack.Count > 2 && PointUtils.EstADroite(beforeLast, last, p[i]))
                {
                    Drawing.Point popped = stack.Pop();
                    beforeLast = stack.ElementAt(1);
                    last = stack.Peek();
                }
                stack.Push(p[i]);
            }
            stack.Push(pmin);
            return stack.ToArray();
        }

        public void TracerEnveloppeConvexe()
        {
            Components.Point[] points = MainCanvas.Children.OfType<Components.Point>().ToArray();
            Drawing.Point[] enveloppeConvexe = Graham(points.Select(s => s.Coord).ToArray());
            
            // Select the points included in the hull and sort them
            // points = points.Where(p => enveloppeConvexe.Contains(p.Coord)).OrderBy(p => p, new ComponentPointComparer(enveloppeConvexe)).Select(p => p).ToArray();
            
            for (int i = 0; i < enveloppeConvexe.Length - 1; i++)
            {
                Drawing.Point cur, next;
                cur = enveloppeConvexe[i];
                next = enveloppeConvexe[i + 1];
                Line line = new Line();
                line.X1 = cur.X;
                line.Y1 = cur.Y;
                line.X2 = next.X;
                line.Y2 = next.Y;
                line.Stroke = Brushes.Blue;
                line.StrokeThickness = 2;
                Canvas.SetZIndex(line, -int.Parse(TBNbr.Text));
                MainCanvas.Children.Add(line);
            }
        }
    }
    public class ComponentPointComparer : IComparer<Components.Point>
    {
        private Drawing.Point[] pointOrder;
        public ComponentPointComparer(Drawing.Point[] pointOrder)
        {
            this.pointOrder = pointOrder;
        }
        public int Compare(Components.Point? x, Components.Point? y)
        {
            return pointOrder.ToList().IndexOf(x.Coord) - pointOrder.ToList().IndexOf(y.Coord);
        }
    }
}