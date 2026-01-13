using System.Windows;
using System.Windows.Controls;
using LogicTier;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                var listBox = sender as ListBox;
                viewModel.ВыбранныйРейс = listBox?.SelectedItem as РейсПозиция;
            }
        }
    }
}