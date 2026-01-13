using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Task5
{
    public partial class MainWindow : Window
    {
        private BindingModel model;

        public MainWindow()
        {
            InitializeComponent();

            model = new BindingModel
            {
                Text = "Текстовая строка",
                FontSize = 20,
                Opacity = 1.0,
                IsBold = false,
                TextColor = Brushes.Blue,
                FontFamily = new FontFamily("Segoe UI")
            };

            DataContext = model;

            // ДИНАМИЧЕСКАЯ ПРИВЯЗКА (IsBold → FontWeight)
            Binding fontWeightBinding = new Binding("IsBold")
            {
                Converter = new BoolToFontWeightConverter()
            };

            txtDemo.SetBinding(TextBlock.FontWeightProperty, fontWeightBinding);
        }
    }
}
