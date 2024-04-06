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
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private Product ProductToUpdate;

        public EditProductWindow(Product product)
        {
            InitializeComponent();

            // Сохраняем информацию о товаре, который нужно отредактировать
            ProductToUpdate = product;

            // Заполняем текстовые поля текущими значениями товара
            NameTextBox.Text = product.Name;
            CategoryTextBox.Text = product.Category;
            QuantityTextBox.Text = product.Quantity.ToString();
            UnitTextBox.Text = product.Unit;
            ManufacturerTextBox.Text = product.Manufacturer;
            PriceTextBox.Text = product.Price.ToString();
            InStockCheckBox.IsChecked = product.InStock;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем информацию о товаре в соответствии с введенными данными
            ProductToUpdate.Name = NameTextBox.Text;
            ProductToUpdate.Category = CategoryTextBox.Text;
            ProductToUpdate.Quantity = int.Parse(QuantityTextBox.Text);
            ProductToUpdate.Unit = UnitTextBox.Text;
            ProductToUpdate.Manufacturer = ManufacturerTextBox.Text;
            ProductToUpdate.Price = decimal.Parse(PriceTextBox.Text);
            ProductToUpdate.InStock = InStockCheckBox.IsChecked ?? false;

            // Сохраняем изменения (в вашем приложении это может быть отправка данных в базу данных)
            // Здесь должен быть ваш код для обновления информации о товаре

            // Закрываем окно редактирования товара
            this.Close();
        }
    }
}
