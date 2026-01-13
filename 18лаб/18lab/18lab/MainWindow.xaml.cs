using System;
using System.Windows;

namespace Lab18_Variant4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(tbX.Text);
                double y = double.Parse(tbY.Text);
                int n = int.Parse(tbN.Text);
                int r = int.Parse(tbR.Text);

                double a = 1;
                double b = 1;
                double c = 1;

                double z = 0;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= r; j++)
                    {
                        double sign = Math.Pow(-1, i + j);
                        double numerator = sign * Math.Pow(y, j) * Math.Pow(x, i);
                        double denominator = a * i + b * j + c;

                        z += numerator / denominator;
                    }
                }

                tbResult.Text = z.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Деление на ноль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
