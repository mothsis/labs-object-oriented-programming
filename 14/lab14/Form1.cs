using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab14
{
    public class Form1 : Form
    {
        private RichTextBox textBox;
        private MenuStrip menu;
        private StatusStrip status;
        private ToolStripStatusLabel statusInfo;

        public Form1()
        {
            this.Text = "ЛР 14 - Вариант 4";
            this.Size = new Size(500, 400);

            // 1. Текстовое поле
            textBox = new RichTextBox { Dock = DockStyle.Fill };
            this.Controls.Add(textBox);

            // 2. Главное меню
            menu = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("Файл");
            fileMenu.DropDownItems.Add("Выход", null, (s, e) => Application.Exit());

            var editMenu = new ToolStripMenuItem("Правка");
            editMenu.DropDownItems.Add("Очистить", null, (s, e) => {
                textBox.Clear();
                statusInfo.Text = "Текст удален";
            });
            editMenu.DropDownItems.Add("Цвет текста", null, (s, e) => {
                using (ColorDialog cd = new ColorDialog())
                    if (cd.ShowDialog() == DialogResult.OK) textBox.ForeColor = cd.Color;
            });

            menu.Items.Add(fileMenu);
            menu.Items.Add(editMenu);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            // 3. Строка состояния
            status = new StatusStrip();
            statusInfo = new ToolStripStatusLabel("Готов");
            status.Items.Add(statusInfo);
            this.Controls.Add(status);

            // 4. Контекстное меню
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Очистить", null, (s, e) => textBox.Clear());
            textBox.ContextMenuStrip = contextMenu;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}