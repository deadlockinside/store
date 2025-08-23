namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private const string Book1Description = "Откройте эту книгу, и из неё выпадет купюра в 5000. Нет, мы шутим. Но вот мысли, которые помогут её заработать, — совершенно нет. Гарантия: ваш кошелёк станет тяжелее, а голова — легче (от гениальных идей).";
        private const string Book2Description = "Бестселлер, который заставляет вас пересмотреть своё отношение к слову 'переплёт'. Для тех, кто считает, что лучший подарок — это не книга, а то, чему она может научить. Продаётся в плёнке, чтобы страницы не слипались от восторга.";
        private const string Book3Description = "Подходит для детей с IQ выше чем 60 (то есть IQ разработчика этого интернет-магазина).";

        private readonly Book[] _books =
        {
            new Book (1, "ISBN 12312-31231", "Гусейн Гасанов", "Мышление миллионера", Book1Description, 3000.00m),
            new Book (2, "ISBN 12312-31232", "Виталий Бойко", "Мастер куннилингуса. Секреты оральных ласк", Book2Description, 5000.00m),
            new Book (3, "ISBN 12312-31233", "Баграт Казарян", "Русский язык 5 класс", Book3Description, 1999.00m)
        };

        public Book[] GetAllByIsbn(string isbn) => _books.Where(book => book.Isbn == isbn).ToArray();

        public Book[] GetAllByTitleOrAutor(string titlePart) => _books.Where(book => book.Title.Contains(titlePart) || book.Autor.Contains(titlePart)).ToArray();

        public Book GetById(int id) => _books.Single(book => book.Id == id);
    }
}
