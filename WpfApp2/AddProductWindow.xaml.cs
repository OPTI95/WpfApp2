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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные о новом товаре из текстовых полей
            string name = NameTextBox.Text;
            string category = CategoryTextBox.Text;
            int quantity = int.Parse(QuantityTextBox.Text);
            string unit = UnitTextBox.Text;
            string manufacturer = ManufacturerTextBox.Text;
            decimal price = decimal.Parse(PriceTextBox.Text);
            bool inStock = InStockCheckBox.IsChecked ?? false;

            // Создаем новый объект товара
            Product newProduct = new Product
            {
                Name = name,
                Category = category,
                Quantity = quantity,
                Unit = unit,
                Manufacturer = manufacturer,
                Price = price,
                InStock = inStock
            };

            // Добавляем новый товар в базу данных или другой источник данных
            // Здесь должен быть ваш код для добавления товара

            // Закрываем окно добавления товара
            this.Close();
        }
    }
}
