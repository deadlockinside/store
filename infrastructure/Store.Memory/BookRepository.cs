namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books =
        {
            new Book (1, "Мышление миллионера"),
            new Book (2, "Мастер куннилингуса. Секреты оральных ласк"),
            new Book (3, "Русский язык 5 класс")
        };

        public Book[] GetAllByTitle(string titlePart) => _books.Where(book => book.Title.Contains(titlePart)).ToArray();
    }
}
