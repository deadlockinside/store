namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books =
        {
            new Book (1, "ISBN 12312-31231", "Гусейн Гасанов", "Мышление миллионера"),
            new Book (2, "ISBN 12312-31232", "Виталий Бойко", "Мастер куннилингуса. Секреты оральных ласк"),
            new Book (3, "ISBN 12312-31233", "Баграт Казарян", "Русский язык 5 класс")
        };

        public Book[] GetAllByIsbn(string isbn) => _books.Where(book => book.Isbn == isbn).ToArray();

        public Book[] GetAllByTitleOrAutor(string titlePart) => _books.Where(book => book.Title.Contains(titlePart) || book.Autor.Contains(titlePart)).ToArray();
    }
}
