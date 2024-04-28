using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            AddoAssistant myTable= new AddoAssistant();
                        list.SelectedIndex = 0;
                        list.Focus();
                        list.DataContext = myTable.TableLoad();
        }
        

        private void ButtonCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = list.SelectedItem as DataRowView;
            var article  = Article.Text;
            var unit = Unit.Text;
            var quantity = Quantity.Text;
            var price = Price.Text;
            new AddoAssistant().CreateItem(article,unit, quantity, price);
            MessageBox.Show("Created successfully");
            
            LoadTable();
        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = list.SelectedItem as DataRowView;
            if (selectedItem is null)
            {
                MessageBox.Show(messageBoxText: "Select item if you want update it, please.",
                    caption: "Error!",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error,
                    defaultResult: MessageBoxResult.OK);
             
                return;
            }
            var id = selectedItem["id"].ToString();
            var article  = Article.Text;
            var unit = Unit.Text;
            var quantity = Quantity.Text;
            var price = Price.Text;
            new AddoAssistant().UpdateItem(id, article,unit, quantity, price);
            MessageBox.Show("Updated successfully");
            LoadTable();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = list.SelectedItem as DataRowView;
            if (selectedItem is null)
            {
                MessageBox.Show(messageBoxText: "Select item if you want delete it, please.",
                    caption: "Error!",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error,
                    defaultResult: MessageBoxResult.OK);
            
                return;
            }
            var id = selectedItem["id"].ToString();
            new AddoAssistant().DeleteItem(id);
            MessageBox.Show("Deleted successfully");
            LoadTable();
        }
    }
}