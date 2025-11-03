using System;

namespace PublicationsApp
{
    // перечисление тип издания
    public enum PubType
    {
        Book,
        Journal,
        EResource
    }

    // Издание
    public class Publication
    {
        public string Title { get; set; }

        // переопределяемое свойство
        public virtual string Info => $"Издание: {Title}";

        public PubType Type { get; protected set; }

        // база конструктор
        public Publication(string title, PubType type)
        {
            Title = title;
            Type = type;
        }

        // переопределяемый метод
        public virtual void ShowInfo()
        {
            Console.WriteLine(Info);
        }
    }

    // книга
    public class Book : Publication
    {
        public string Author { get; set; }

        // Конструктор вызывает базовый
        public Book(string title, string author)
            : base(title, PubType.Book)
        {
            Author = author;
        }

        // Переопределение свойства
        public override string Info => $"Книга: {Title}, Автор: {Author}";

        // Переопределение метода
        public override void ShowInfo()
        {
            base.ShowInfo(); // ✅ Вызов базового метода
        }
    }

    // Журнал
    public class Journal : Publication
    {
        public int Issue { get; set; }

        public Journal(string title, int issue)
            : base(title, PubType.Journal)
        {
            Issue = issue;
        }

        public override string Info => $"Журнал: {Title}, Выпуск №{Issue}";
    }

    // электронный ресурс
    public class EResource : Publication
    {
        public string Url { get; set; }

        public EResource(string title, string url)
            : base(title, PubType.EResource)
        {
            Url = url;
        }

        public override string Info => $"Электронный ресурс: {Title}, URL: {Url}";
    }

    class Program
    {
        static void Main()
        {
            // массив база
            Publication[] library =
            {
                new Book("Мастер и Маргарита", "М. Булгаков"),
                new Journal("National Geographic", 202),
                new EResource("Wikipedia", "https://wikipedia.org")
            };

            Console.WriteLine("Библиотека содержит:");

            foreach (var pub in library)
            {
                pub.ShowInfo(); // вызов
            }

            Console.ReadKey();
        }
    }
}
