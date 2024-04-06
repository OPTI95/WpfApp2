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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int FailedLoginAttempts = 0;
        private const int MaxFailedLoginAttempts = 3;
        private bool Blocked = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Проверка учетных данных и авторизация
            if (CheckCredentials(username, password))
            {
                // Отображение главного окна или другого функционала
                MessageBox.Show("Авторизация успешна!");
            }
            else
            {
                // Отображение сообщения об ошибке при неудачной авторизации
                ErrorTextBlock.Text = "Неверный логин или пароль!";
                FailedLoginAttempts++;

                // Проверка на необходимость отображения CAPTCHA и блокировки
                if (FailedLoginAttempts >= MaxFailedLoginAttempts)
                {
                    ShowCaptcha();
                }
            }
        }

        private bool CheckCredentials(string username, string password)
        {
            // Проверка учетных данных в базе данных или другом хранилище
            return true; // Ваша реализация проверки учетных данных
        }

        private void ShowCaptcha()
        {
            // Отображение CAPTCHA
            Blocked = true;
            ErrorTextBlock.Text = "Введите CAPTCHA";
            // Реализация CAPTCHA
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Вернуться на главный экран или закрыть приложение
        }
    }
}
