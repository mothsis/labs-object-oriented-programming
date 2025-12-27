using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab15
{
    public class Form1 : Form
    {
        private DataGridView dgv;
        private TextBox txtX, txtN;
        private Button btnCalc;
        private Label lblFinal;

        public Form1()
        {
            this.Text = "ЛР 15 - Вариант 4: Вычисление выражения";
            this.Size = new Size(650, 500);

            // Интерфейс для ввода
            Label labelX = new Label { Text = "Параметр x:", Location = new Point(10, 20), Width = 80 };
            txtX = new TextBox { Location = new Point(90, 18), Width = 60, Text = "1" };

            Label labelN = new Label { Text = "Кол-во слагаемых:", Location = new Point(170, 20), Width = 120 };
            txtN = new TextBox { Location = new Point(290, 18), Width = 60, Text = "4" };

            btnCalc = new Button { Text = "Рассчитать", Location = new Point(370, 15), Width = 100 };
            btnCalc.Click += CalculateExpression;

            // Таблица для вывода этапов (как требуют в лабах с циклами)
            dgv = new DataGridView {
                Location = new Point(10, 60),
                Size = new Size(610, 350),
                ColumnCount = 4,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgv.Columns[0].Name = "i (шаг)";
            dgv.Columns[1].Name = "Числитель";
            dgv.Columns[2].Name = "Знаменатель";
            dgv.Columns[3].Name = "Значение";

            lblFinal = new Label { 
                Text = "Результат h = ", 
                Location = new Point(10, 420), 
                Width = 400, 
                Font = new Font("Arial", 10, FontStyle.Bold) 
            };

            this.Controls.AddRange(new Control[] { labelX, txtX, labelN, txtN, btnCalc, dgv, lblFinal });
        }

        private void CalculateExpression(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(txtX.Text);
                int n = int.Parse(txtN.Text);
                double h = 0;
                dgv.Rows.Clear();

                for (int i = 1; i <= n; i++)
                {
                    // Логика по твоей формуле:
                    // Степени x: 1, 3, 5, 7... -> это (2*i - 1)
                    int p = 2 * i - 1;
                    
                    // Знаменатели: 1*3 (i=1), 2*4 (i=2), 5*7 (i=3), 6*8 (i=4)
                    // Заметим закономерность: для нечетных i: (2i-1)*(2i+1), для четных i: (i)*(i+2)
                    double denominator;
                    if (i % 2 != 0) 
                        denominator = p * (p + 2);
                    else 
                        denominator = i * (i + 2);

                    double numerator = Math.Sin(Math.Pow(x, p));
                    double term = numerator / denominator;

                    // Чередование знаков: +, -, +, - ...
                    if (i % 2 == 0) term = -term;

                    h += term;

                    // Добавляем строку в таблицу
                    dgv.Rows.Add(i, $"sin(x^{p})", denominator, term.ToString("F6"));
                }

                lblFinal.Text = $"Результат h = {h:F6}";
            }
            catch
            {
                MessageBox.Show("Введите корректные числовые значения!");
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}