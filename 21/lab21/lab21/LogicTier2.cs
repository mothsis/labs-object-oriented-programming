using DataTier;  // УБЕДИТЕСЬ, ЧТО ЭТА СТРОЧКА ЕСТЬ
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LogicTier
{
    public class РейсМенеджер
    {
        public ObservableCollection<РейсПозиция> СписокРейсов { get; }
            = new ObservableCollection<РейсПозиция>();

        public void ЗагрузитьИзФайла(string path)
        {
            СписокРейсов.Clear();

            if (!File.Exists(path))
            {
                // Создаем тестовые данные, если файла нет
                СоздатьТестовыеДанные();
                return;
            }

            foreach (var line in File.ReadAllLines(path))
            {
                // Разделяем по звездочке как в примере
                var parts = line.Split('*');

                if (parts.Length >= 4)
                {
                    // Пропускаем номер в начале, если есть
                    int startIndex = parts[0].All(char.IsDigit) ? 1 : 0;

                    var рейс = new Рейс
                    {
                        Транспорт = parts[startIndex].Trim(),
                        ПунктОтправки = parts[startIndex + 1].Trim(),
                        ПунктНазначения = parts[startIndex + 2].Trim(),
                        Стоимость = double.Parse(parts[startIndex + 3].Trim())
                    };

                    СписокРейсов.Add(new РейсПозиция(рейс));
                }
            }
        }

        private void СоздатьТестовыеДанные()
        {
            var тестовыеРейсы = new[]
            {
                new Рейс { Транспорт = "Самолет", ПунктОтправки = "Москва", ПунктНазначения = "Пекин", Стоимость = 30000.00 },
                new Рейс { Транспорт = "Автобус", ПунктОтправки = "Ставрополь", ПунктНазначения = "Москва", Стоимость = 3000.00 },
                new Рейс { Транспорт = "Автобус", ПунктОтправки = "Невинномысск", ПунктНазначения = "Ставрополь", Стоимость = 10.00 },
                new Рейс { Транспорт = "Автобус", ПунктОтправки = "Москва", ПунктНазначения = "Владивосток", Стоимость = 50000 },
                new Рейс { Транспорт = "Самолет", ПунктОтправки = "СПб", ПунктНазначения = "Москва", Стоимость = 1500 }
            };

            foreach (var рейс in тестовыеРейсы)
            {
                СписокРейсов.Add(new РейсПозиция(рейс));
            }
        }

        public int КоличествоАвтобусов =>
            СписокРейсов.Count(r => r.Транспорт == "Автобус");

        public double СуммаСамолетов =>
            СписокРейсов.Where(r => r.Транспорт == "Самолет")
                        .Sum(r => r.Стоимость);

        public double СамыйДорогой =>
            СписокРейсов.Count > 0 ? СписокРейсов.Max(r => r.Стоимость) : 0;
    }
}