using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LogicTier;
using DataTier;

namespace Presentation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly РейсМенеджер _менеджер = new РейсМенеджер();
        private РейсПозиция _выбранныйРейс;

        public MainViewModel()
        {
            // Загружаем данные из файла
            _менеджер.ЗагрузитьИзФайла("input.txt");
        }

        public ObservableCollection<РейсПозиция> Рейсы => _менеджер.СписокРейсов;

        public РейсПозиция ВыбранныйРейс
        {
            get => _выбранныйРейс;
            set
            {
                _выбранныйРейс = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ЕстьВыбранныйРейс));
            }
        }

        public bool ЕстьВыбранныйРейс => ВыбранныйРейс != null;

        public int АвтобусныхРейсов => _менеджер.КоличествоАвтобусов;

        public double СтоимостьСамолетов => _менеджер.СуммаСамолетов;

        public double СамыйДорогойБилет => _менеджер.СамыйДорогой;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}