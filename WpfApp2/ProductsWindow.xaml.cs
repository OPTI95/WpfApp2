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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private ObservableCollection<Product> Products = new ObservableCollection<Product>();

        public ProductsWindow()
        {
            InitializeComponent();
        }

        private void LoadProducts()
        {
            // Предположим, что у вас есть некий сервис или класс, который загружает товары из базы данных
            List<Product> productsFromDatabase = ProductService.GetProducts(); // Метод GetProducts() должен быть реализован в вашем классе сервиса

            // Добавляем загруженные товары в коллекцию Products
            foreach (Product product in productsFromDatabase)
            {
                Products.Add(product);
            }
        }

        private void UpdateDataGrid()
        {
            // Обновляем источник данных для DataGrid
            ProductsDataGrid.ItemsSource = Products;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower(); // Получаем текст поиска и приводим его к нижнему регистру для удобства поиска

            // Фильтруем список товаров по тексту поиска
            var filteredProducts = Products.Where(p =>
                p.Name.ToLower().Contains(searchText) ||
                p.Category.ToLower().Contains(searchText) ||
                p.Manufacturer.ToLower().Contains(searchText)
            ).ToList();

            // Обновляем отображаемые данные в DataGrid
            ProductsDataGrid.ItemsSource = filteredProducts;
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Логика обработки изменения выбранного товара в таблице
            // Например, можно вывести информацию о выбранном товаре в другом элементе управления
            Product selectedProduct = (Product)ProductsDataGrid.SelectedItem;
            if (selectedProduct != null)
            {
                MessageBox.Show($"Вы выбрали товар: {selectedProduct.Name}");
            }
        }
    }
}
