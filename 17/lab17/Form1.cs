using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab17
{
    // Класс дочернего окна
    public class ChildForm : Form
    {
        public ChildForm(string title)
        {
            this.Text = title;
            RichTextBox rtb = new RichTextBox { Dock = DockStyle.Fill };
            this.Controls.Add(rtb);
        }
    }

    // Класс главного родительского окна
    public class ParentForm : Form
    {
        private int childCount = 0;

        public ParentForm()
        {
            this.Text = "ЛР 17 - MDI Приложение (Вариант 4)";
            this.Size = new Size(800, 600);
            
            // Включаем режим MDI
            this.IsMdiContainer = true;

            // Создаем меню
            MenuStrip ms = new MenuStrip();
            
            // Меню "Окно"
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Окна");
            
            ToolStripMenuItem createItem = new ToolStripMenuItem("Создать новое", null, (s, e) => {
                childCount++;
                ChildForm child = new ChildForm("Документ " + childCount);
                child.MdiParent = this; // Указываем, кто родитель
                child.Show();
            });

            ToolStripMenuItem layoutCascade = new ToolStripMenuItem("Каскад", null, (s, e) => {
                this.LayoutMdi(MdiLayout.Cascade);
            });

            ToolStripMenuItem layoutTileH = new ToolStripMenuItem("Горизонтально", null, (s, e) => {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            });

            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход", null, (s, e) => Application.Exit());

            windowMenu.DropDownItems.Add(createItem);
            windowMenu.DropDownItems.Add(new ToolStripSeparator());
            windowMenu.DropDownItems.Add(layoutCascade);
            windowMenu.DropDownItems.Add(layoutTileH);
            windowMenu.DropDownItems.Add(new ToolStripSeparator());
            windowMenu.DropDownItems.Add(exitItem);

            ms.Items.Add(windowMenu);
            this.MainMenuStrip = ms;
            this.Controls.Add(ms);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new ParentForm());
        }
    }
}