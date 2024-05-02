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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Lab5DbContext _context;
        private List<Product> _products;
        private List<Unit> _units;
        public MainWindow()
        {
            InitializeComponent();
            _context = new Lab5DbContext();
            _products = _context.Products.ToList();
            _units = _context.Units.ToList();
            dataGrid1.ItemsSource = _products;
            dataGrid2.ItemsSource = _units;
        }

    }
}