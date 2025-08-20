using Moq;

namespace Store.Tests
{
    public class BookServiceTests
    {
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
    }
}
