using System;
using System.Text;
using System.Threading;
using System.Windows;
using Logic;

namespace Lab22
{
    public partial class MainWindow : Window
    {
        private MatrixGeneratorDelegate _generator;

        public MainWindow()
        {
            InitializeComponent();
            _generator = MatrixGeneratorLogic.GenerateMatrix;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbRows.Text, out int rows) ||
                !int.TryParse(tbCols.Text, out int cols))
            {
                MessageBox.Show("Введите корректные размеры матрицы");
                return;
            }

            tbStatus.Text = "Метод выполняется...";
            tbResult.Clear();

            // Асинхронный запуск
            _generator.BeginInvoke(rows, cols, Callback, null);
        }

        // Callback — получение результата
        private void Callback(IAsyncResult ar)
        {
            int[,] matrix = _generator.EndInvoke(ar);

            Dispatcher.Invoke(() =>
            {
                tbStatus.Text = "Выполнение завершено";
                tbResult.Text = MatrixToString(matrix);
            });
        }

        private string MatrixToString(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sb.Append(matrix[i, j] + " ");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
