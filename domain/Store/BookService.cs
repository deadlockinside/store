namespace Store
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query) 
        { 
            if (Book.IsIsbn(query))
                return _bookRepository.GetAllByIsbn(query);

            return _bookRepository.GetAllByTitleOrAutor(query);
        }
    }
}
