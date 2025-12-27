using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        // Объявляем элементы интерфейса (как поля класса)
        private Label labelF;
        private Label labelE;
        private Label labelW;
        private Label labelX;
        private Label labelY;
        private TextBox textBoxF;
        private TextBox textBoxE;
        private TextBox textBoxW;
        private TextBox textBoxX;
        private TextBox textBoxY;

        public Form1()
        {
            InitializeComponent();  // Вызов существующего метода из Designer.cs (не удаляйте!)

            // Добавляем элементы вручную после инициализации формы
            // Label и TextBox для f
            labelF = new Label { Text = "f:", Location = new Point(10, 10), AutoSize = true };
            textBoxF = new TextBox { Location = new Point(50, 10), Width = 100 };

            // Label и TextBox для e
            labelE = new Label { Text = "e:", Location = new Point(10, 40), AutoSize = true };
            textBoxE = new TextBox { Location = new Point(50, 40), Width = 100 };

            // Label и TextBox для w
            labelW = new Label { Text = "w:", Location = new Point(10, 70), AutoSize = true };
            textBoxW = new TextBox { Location = new Point(50, 70), Width = 100 };

            // Label и TextBox для x (read-only, от мыши)
            labelX = new Label { Text = "x:", Location = new Point(10, 100), AutoSize = true };
            textBoxX = new TextBox { Location = new Point(50, 100), Width = 100, ReadOnly = true };

            // Label и TextBox для y (read-only, от мыши)
            labelY = new Label { Text = "y:", Location = new Point(10, 130), AutoSize = true };
            textBoxY = new TextBox { Location = new Point(50, 130), Width = 100, ReadOnly = true };

            // Добавляем все элементы на форму
            this.Controls.Add(labelF);
            this.Controls.Add(textBoxF);
            this.Controls.Add(labelE);
            this.Controls.Add(textBoxE);
            this.Controls.Add(labelW);
            this.Controls.Add(textBoxW);
            this.Controls.Add(labelX);
            this.Controls.Add(textBoxX);
            this.Controls.Add(labelY);
            this.Controls.Add(textBoxY);

            // Привязываем событие движения мыши
            this.MouseMove += Form1_MouseMove;

            // Начальные свойства формы (если нужно)
            this.Text = "Lab 12 Variant 4";
            this.Size = new Size(300, 200);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Обновляем координаты мыши в read-only TextBox
            textBoxX.Text = e.X.ToString();
            textBoxY.Text = e.Y.ToString();

            try
            {
                // Парсим вводимые значения
                double f = double.Parse(textBoxF.Text);
                double ee = double.Parse(textBoxE.Text);  // e — зарезервировано, используем ee
                double w = double.Parse(textBoxW.Text);
                double y = double.Parse(textBoxY.Text);  // y от мыши (используется в cos(y))

                // Проверки на ошибки: деление на 0, отрицательный корень
                if (w == 0 || (f - ee / w) < 0)
                    throw new Exception("Недопустимые значения");

                // Расчёт выражения U (из методички, вариант 4)
                double sinSquared = Math.Pow(Math.Sin(ee / w), 2);
                double u = Math.Sqrt(f - ee / w) + Math.Abs(sinSquared + Math.Cos(y));

                // Вывод результата в заголовок формы
                this.Text = $"U = {u:F4}";
            }
            catch
            {
                // Ошибка: неверный ввод, деление на 0 и т.д.
                this.Text = "ERROR";
            }
        }
    }
}