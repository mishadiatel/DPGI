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
using Microsoft.EntityFrameworkCore;

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

            JoinTables();
        }

        private void JoinTables()
        {
            try
            {
                var query = from product in _context.Products
                    join unit in _context.Units
                        on product.Unitcode equals unit.Id
                    select new
                    {
                        product.Id,
                        product.Article,
                        product.Unitcode,
                        unit.Unit1,
                        product.Quantity,
                        product.Price
                    };
                gridJoin.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SelectByIdButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var products = _context.Products.Where(b => b.Id == Int32.Parse(idTextBox.Text))
                    .ToList();
                idGrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SelectByNameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var books = _context.Products.FromSqlRaw($"SELECT * FROM products WHERE article LIKE '{nameTextBox.Text}%'").ToList();
                nameGrid.ItemsSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}