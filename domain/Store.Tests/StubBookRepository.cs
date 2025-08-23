namespace Store.Tests
{
    internal class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByIsbn { get; set; }

        public Book[] ResultOfGetAllByTitleOrAutor { get; set; }

        public Book[] GetAllByIsbn(string isbn) => ResultOfGetAllByIsbn;

        public Book[] GetAllByTitleOrAutor(string titleOrAutor) => ResultOfGetAllByTitleOrAutor;

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
