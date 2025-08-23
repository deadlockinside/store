using Moq;

namespace Store.Tests
{
    public class BookServiceTests
    {
        /*
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn() 
        {
            var bookPepositoryStub = new Mock<IBookRepository>();
            bookPepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "")});
            bookPepositoryStub.Setup(x => x.GetAllByTitleOrAutor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookPepositoryStub.Object);
            var actual = bookService.GetAllByQuery("ISBN 12345-67890");

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
        
        [Fact]
        public void GetAllByQuery_WithAutor_CallsGetAllByTitleOrAutor() 
        {
            var bookPepositoryStub = new Mock<IBookRepository>();
            bookPepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "") });
            bookPepositoryStub.Setup(x => x.GetAllByTitleOrAutor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookPepositoryStub.Object);
            var actual = bookService.GetAllByQuery("12345-67890");

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
        */

        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn() 
        {
            const int idOfIsbnSearch = 1;
            const int idOfAutorSearch = 2;

            var bookPepository = new StubBookRepository();

            bookPepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 1.00m)
            };

            bookPepository.ResultOfGetAllByTitleOrAutor = new[]
            {
                new Book(idOfAutorSearch, "", "", "", "", 1.00m)
            };

            var bookService = new BookService(bookPepository);
            var books = bookService.GetAllByQuery("ISBN 12345-67890");

            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAutor_CallsGetAllByTitleOrAutor() 
        {
            const int idOfIsbnSearch = 1;
            const int idOfAutorSearch = 2;

            var bookPepository = new StubBookRepository();

            bookPepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 1.00m)
            };

            bookPepository.ResultOfGetAllByTitleOrAutor = new[]
            {
                new Book(idOfAutorSearch, "", "", "", "", 1.00m)
            };

            var bookService = new BookService(bookPepository);
            var books = bookService.GetAllByQuery("Баграт");

            Assert.Collection(books, book => Assert.Equal(idOfAutorSearch, book.Id));
        }
    }
}
