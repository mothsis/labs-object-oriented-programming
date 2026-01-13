using DataTier;

namespace LogicTier
{
    public class РейсПозиция
    {
        private Рейс _рейс;

        public РейсПозиция(Рейс r)
        {
            _рейс = r;
        }

        public string Транспорт
        {
            get => _рейс.Транспорт;
            set => _рейс.Транспорт = value;
        }

        public string ПунктОтправки
        {
            get => _рейс.ПунктОтправки;
            set => _рейс.ПунктОтправки = value;
        }

        public string ПунктНазначения
        {
            get => _рейс.ПунктНазначения;
            set => _рейс.ПунктНазначения = value;
        }

        public double Стоимость
        {
            get => _рейс.Стоимость;
            set => _рейс.Стоимость = value;
        }

        public string ПредставлениеРейса
        {
            get => $"{Транспорт}: {ПунктОтправки} → {ПунктНазначения} ({Стоимость:C})";
        }
    }
}