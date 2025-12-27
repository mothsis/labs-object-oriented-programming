using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab16
{
    public class Form1 : Form
    {
        private DataGridView dgv;
        private Button btnAdd, btnAnalyze;
        private ListBox resList;

        public Form1()
        {
            this.Text = "ЛР 16 - Вариант 4 (Задолженности)";
            this.Size = new Size(800, 500);

            // Таблица ввода
            dgv = new DataGridView { 
                Location = new Point(10, 10), 
                Size = new Size(550, 300),
                ColumnCount = 4,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 
            };
            dgv.Columns[0].Name = "ФИО";
            dgv.Columns[1].Name = "Группа";
            dgv.Columns[2].Name = "Курс";
            dgv.Columns[3].Name = "Долги";

            // Тестовые данные для быстроты
            dgv.Rows.Add("Иванов И.И.", "ИСТ-11", "1", "2");
            dgv.Rows.Add("Петров П.П.", "ИСТ-21", "2", "0");
            dgv.Rows.Add("Сидоров С.С.", "ИСТ-11", "1", "3");

            btnAdd = new Button { Text = "Добавить строку", Location = new Point(10, 320), Width = 120 };
            btnAdd.Click += (s, e) => dgv.Rows.Add();

            btnAnalyze = new Button { Text = "Выполнить расчет", Location = new Point(140, 320), Width = 150 };
            btnAnalyze.Click += AnalyzeData;

            // Список для вывода итогов
            resList = new ListBox { Location = new Point(570, 10), Size = new Size(200, 300) };

            this.Controls.AddRange(new Control[] { dgv, btnAdd, btnAnalyze, resList });
        }

        private void AnalyzeData(object sender, EventArgs e)
        {
            resList.Items.Clear();
            var courseDebts = new Dictionary<string, int>();
            int zeroDebtCount = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow || row.Cells[2].Value == null || row.Cells[3].Value == null) continue;

                string course = row.Cells[2].Value.ToString();
                int debts = int.Parse(row.Cells[3].Value.ToString());

                // 1. Считаем долги по курсу
                if (courseDebts.ContainsKey(course))
                    courseDebts[course] += debts;
                else
                    courseDebts[course] = debts;

                // 2. Считаем студентов без долгов
                if (debts == 0) zeroDebtCount++;
            }

            resList.Items.Add("Долги по курсам:");
            foreach (var pair in courseDebts.OrderBy(p => p.Key))
            {
                resList.Items.Add($"Курс {pair.Key}: {pair.Value}");
            }
            resList.Items.Add("-------------------");
            resList.Items.Add($"Без долгов: {zeroDebtCount}");
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}