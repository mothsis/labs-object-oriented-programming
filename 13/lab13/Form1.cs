using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13 // Название совпадает с твоей папкой
{
    public class Form1 : Form
    {
        // Элементы управления
        private Label labelX;
        private Label labelY;
        private Label labelResult;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private TextBox textBoxResult;
        private Button buttonCalc;
        private GroupBox groupBoxFormulas;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBoxFlag;

        public Form1()
        {
            this.Text = "ЛР 13 - Вариант 4";
            this.Size = new Size(360, 380);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponentManual();
        }

        private void InitializeComponentManual()
        {
            // 1. Метка X
            labelX = new Label();
            labelX.Text = "Введите X:";
            labelX.Location = new Point(20, 20);
            labelX.AutoSize = true;
            this.Controls.Add(labelX);

            // 2. Поле X
            textBoxX = new TextBox();
            textBoxX.Location = new Point(100, 17);
            textBoxX.Width = 100;
            this.Controls.Add(textBoxX);

            // 3. Метка Y
            labelY = new Label();
            labelY.Text = "Введите Y:";
            labelY.Location = new Point(20, 50);
            labelY.AutoSize = true;
            this.Controls.Add(labelY);

            // 4. Поле Y
            textBoxY = new TextBox();
            textBoxY.Location = new Point(100, 47);
            textBoxY.Width = 100;
            this.Controls.Add(textBoxY);

            // 5. Группа формул
            groupBoxFormulas = new GroupBox();
            groupBoxFormulas.Text = "Выбор формулы";
            groupBoxFormulas.Location = new Point(20, 90);
            groupBoxFormulas.Size = new Size(280, 80);
            this.Controls.Add(groupBoxFormulas);

            // Радиокнопка 1
            radioButton1 = new RadioButton();
            radioButton1.Text = "sin(x) + y^2"; // Пример формулы
            radioButton1.Location = new Point(15, 20);
            radioButton1.Width = 250;
            radioButton1.Checked = true;
            groupBoxFormulas.Controls.Add(radioButton1);

            // Радиокнопка 2
            radioButton2 = new RadioButton();
            radioButton2.Text = "x * y"; // Пример формулы
            radioButton2.Location = new Point(15, 45);
            radioButton2.Width = 250;
            groupBoxFormulas.Controls.Add(radioButton2);

            // 6. Чекбокс
            checkBoxFlag = new CheckBox();
            checkBoxFlag.Text = "Модуль результата";
            checkBoxFlag.Location = new Point(20, 180);
            checkBoxFlag.Width = 200;
            this.Controls.Add(checkBoxFlag);

            // 7. Кнопка
            buttonCalc = new Button();
            buttonCalc.Text = "Вычислить";
            buttonCalc.Location = new Point(20, 210);
            buttonCalc.Width = 100;
            buttonCalc.Click += ButtonCalc_Click;
            this.Controls.Add(buttonCalc);

            // 8. Результат
            labelResult = new Label();
            labelResult.Text = "Результат:";
            labelResult.Location = new Point(20, 250);
            labelResult.AutoSize = true;
            this.Controls.Add(labelResult);

            textBoxResult = new TextBox();
            textBoxResult.Location = new Point(100, 247);
            textBoxResult.Width = 100;
            textBoxResult.ReadOnly = true;
            this.Controls.Add(textBoxResult);
        }

        private void ButtonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBoxX.Text);
                double y = double.Parse(textBoxY.Text);
                double result = 0;

                // --- ФОРМУЛЫ ВАРИАНТА 4 ---
                // Замени их на точные из задания, если они другие
                if (radioButton1.Checked)
                {
                    // Формула 1
                    result = Math.Sin(x) + Math.Pow(y, 2);
                }
                else
                {
                    // Формула 2
                    result = x * y;
                }

                if (checkBoxFlag.Checked)
                {
                    result = Math.Abs(result);
                }

                textBoxResult.Text = Math.Round(result, 3).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ТОЧКА ВХОДА В ПРОГРАММУ
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}