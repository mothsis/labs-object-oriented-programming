using System.ComponentModel;

namespace Lab20_Variant4
{
    public class DataModel : INotifyPropertyChanged
    {
        private double x;
        private double y;

        public double X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
                OnPropertyChanged(nameof(Result));
            }
        }

        public double Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
                OnPropertyChanged(nameof(Result));
            }
        }

        public double Result => X + Y;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
