using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Drawing = System.Drawing;

namespace ApplicationEnveloppeConvexe.Components
{
    /// <summary>
    /// Logique d'interaction pour Point.xaml
    /// </summary>
    public partial class Point : UserControl
    {
        private Drawing.Point point;
        public Drawing.Point Coord
        {
            get { return point; }
            set
            {
                point = value;
                UICoord.Text = $"({value.X}, {value.Y})";
                Canvas.SetTop(this, value.Y - 5);
                Canvas.SetLeft(this, value.X - 5);
            }
        }
        public Point(Drawing.Point point)
        {
            InitializeComponent();
            this.Coord = point;
            Cursor = Cursors.Hand;
            MouseMove += UIPoint_MouseMove;
            MouseLeave += UIPoint_MouseLeave;
            var tooltip = new ToolTip();
            tooltip.Content = UICoord.Text;
            ToolTip = tooltip;
        }

        private void UIPoint_MouseLeave(object sender, MouseEventArgs e)
        {
            ShowCoord(false);
        }

        private void ShowCoord(bool mouseenter)
        {
            if (mouseenter)
            {
                UICoord.Visibility = Visibility.Visible;
            }
            else
            {
                UICoord.Visibility = Visibility.Collapsed;
            }
        }

        private void UIPoint_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoord(true);
        }

        public Point(int X, int Y): this(new Drawing.Point(X, Y))
        {
        }
    }
}
