using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class ProductService
    {
        // Метод для загрузки списка товаров из базы данных
        public static List<Product> GetProducts()
        {
            // Ваша реализация загрузки товаров из базы данных
            // Здесь предполагается, что вы имеете доступ к вашему источнику данных,
            // такому как база данных, и загружаете товары из него
            // В данном примере мы просто вернем фиктивный список товаров для демонстрационных целей

            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Золотое кольцо", Category = "Украшения", Quantity = 10, Unit = "шт", Manufacturer = "Завод Золото", Price = 10000, InStock = true },
                new Product { Id = 2, Name = "Серебряные серьги", Category = "Украшения", Quantity = 5, Unit = "пара", Manufacturer = "Серебряный Мир", Price = 5000, InStock = true },
                new Product { Id = 3, Name = "Браслет из белого золота", Category = "Украшения", Quantity = 0, Unit = "шт", Manufacturer = "Завод Золото", Price = 15000, InStock = false },
                // Добавьте другие товары, если необходимо
            };

            return products;
        }
    }
}
