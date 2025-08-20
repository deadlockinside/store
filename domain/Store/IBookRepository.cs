namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitleOrAutor(string titleOrAutor);
    }
}
