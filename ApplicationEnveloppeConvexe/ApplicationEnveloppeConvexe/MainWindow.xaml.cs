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
            // Afficher les points sur le Canvas
            TextRange textRange = new TextRange(
                RTBCoord.Document.ContentStart,
                RTBCoord.Document.ContentEnd
            );
            foreach (string line in textRange.Text.Split(Environment.NewLine))
            {
                Debug.WriteLine(line);
            }
        }
    }
}