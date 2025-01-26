using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tsyguleva_Zokirova_422
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, введено ли значение
            if (string.IsNullOrWhiteSpace(InputX.Text))
            {
                MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double x;
            // Проверка, является ли значение числом
            if (!double.TryParse(InputX.Text, out x))
            {
                MessageBox.Show("Введите корректное число для x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка, выбрана ли функция
            if (!(FuncSh.IsChecked == true || FuncSquare.IsChecked == true || FuncExp.IsChecked == true))
            {
                MessageBox.Show("Выберите функцию f(x)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Вычисление f(x)
            double f_x = 0;
            if (FuncSh.IsChecked == true)
            {
                f_x = Math.Sinh(x); // sh(x)
            }
            else if (FuncSquare.IsChecked == true)
            {
                f_x = Math.Pow(x, 2); // x²
            }
            else if (FuncExp.IsChecked == true)
            {
                f_x = Math.Exp(x); // e^x
            }

            // Выбор e в зависимости от условий
            double result = 0;
            int i = 1;
            if (i % 2 != 0 && x > 0)
            {
                result = i * Math.Sqrt(f_x);
            }
            else if (i % 2 == 0 && x < 0)
            {
                result = (i / 2.0) * Math.Sqrt(Math.Abs(f_x));
            }
            else
            {
                result = Math.Sqrt(Math.Abs(f_x));
            }

            // Вывод результата
            ResultBox.Text = $"e = {result}";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            
            InputX.Text = string.Empty;
            ResultBox.Text = string.Empty;
            FuncSh.IsChecked = false;
            FuncSquare.IsChecked = false;
            FuncExp.IsChecked = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Подтверждение выхода
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
    }
}  