using System.ComponentModel;
using System.Windows.Media;

namespace Task5
{
    public class BindingModel : INotifyPropertyChanged
    {
        private string text;
        private int fontSize;
        private double opacity;
        private bool isBold;
        private Brush textColor;
        private FontFamily fontFamily;

        public string Text
        {
            get => text;
            set { text = value; OnPropertyChanged(nameof(Text)); }
        }

        public int FontSize
        {
            get => fontSize;
            set { fontSize = value; OnPropertyChanged(nameof(FontSize)); }
        }

        public double Opacity
        {
            get => opacity;
            set { opacity = value; OnPropertyChanged(nameof(Opacity)); }
        }

        public bool IsBold
        {
            get => isBold;
            set { isBold = value; OnPropertyChanged(nameof(IsBold)); }
        }

        public Brush TextColor
        {
            get => textColor;
            set { textColor = value; OnPropertyChanged(nameof(TextColor)); }
        }

        public FontFamily FontFamily
        {
            get => fontFamily;
            set { fontFamily = value; OnPropertyChanged(nameof(FontFamily)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
