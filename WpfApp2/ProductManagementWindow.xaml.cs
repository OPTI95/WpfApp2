using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        private ObservableCollection<Product> Products = new ObservableCollection<Product>();

        public ProductManagementWindow()
        {
            InitializeComponent();
            LoadProducts(); // Загрузка товаров из базы данных
            UpdateDataGrid();
        }

        private void LoadProducts()
        {
            // Предположим, что у вас есть сервис ProductService, который предоставляет список товаров из базы данных
            Products = new ObservableCollection<Product>(ProductService.GetProducts());
        }

        private void UpdateDataGrid()
        {
            ProductsDataGrid.ItemsSource = Products;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно добавления товара
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();

            // Обновить список товаров после добавления
            LoadProducts();
            UpdateDataGrid();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка выбранного товара для редактирования
            Product selectedProduct = (Product)ProductsDataGrid.SelectedItem;
            if (selectedProduct != null)
            {
                // Открыть окно редактирования товара
                EditProductWindow editProductWindow = new EditProductWindow(selectedProduct);
                editProductWindow.ShowDialog();

                // Обновить список товаров после редактирования
                LoadProducts();
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.");
            }
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка выбранного товара для удаления
            Product selectedProduct = (Product)ProductsDataGrid.SelectedItem;
            if (selectedProduct != null)
            {
                // Проверка наличия товара в заказах перед удалением
                if (CheckProductInOrders(selectedProduct))
                {
                    MessageBox.Show("Нельзя удалить товар, который присутствует в заказах.");
                }
                else
                {
                    // Удаление товара
                    Products.Remove(selectedProduct);

                    // Обновить список товаров после удаления
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }

        private bool CheckProductInOrders(Product product)
        {
            // Логика проверки наличия товара в заказах
            // В данном примере всегда возвращается false
            return false;
        }
    }
}
