using BooksManager.Common;
using Moq;

namespace BooksManager.BooksService.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void GetBookWithBestPricePagesRatio_2_Books_results_the_Book_2_TestRepo()
        {
            var service = new BooksService(new TestRepo());

            var result = service.GetBookWithBestPricePagesRatio();

            Assert.Equal("Book 2", result.Title);
        }

        [Fact]
        public void GetBookWithBestPricePagesRatio_2_Books_results_the_Book_2_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetBooks()).Returns(() =>
            {
                var b1 = new Book() { Title = "Book 1", Pages = 100, Price = 50 };
                var b2 = new Book() { Title = "Book 2", Pages = 200, Price = 50 };
                return new Book[] { b1, b2 };
            });
            var service = new BooksService(mock.Object);

            var result = service.GetBookWithBestPricePagesRatio();

            Assert.Equal("Book 2", result.Title);
        }

        [Fact]
        public void GetBookWithBestPricePagesRatio_empty_repo_should_return_null()
        {
            var mock = new Mock<IRepository>();
            var service = new BooksService(mock.Object);

            var result = service.GetBookWithBestPricePagesRatio();

            Assert.Null(result);
        }

        [Fact]
        public void GetBookWithBestPricePagesRatio_2_books_with_equal_ratio_should_return_the_cheaper_one()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetBooks()).Returns(() =>
            {
                var b1 = new Book() { Title = "Book 1", Pages = 200, Price = 100 };
                var b2 = new Book() { Title = "Book 2", Pages = 100, Price = 50 };
                var b3 = new Book() { Title = "Book 3", Pages = 300, Price = 150 };
                return new Book[] { b1, b2, b3 };
            });
            var service = new BooksService(mock.Object);

            var result = service.GetBookWithBestPricePagesRatio();

            Assert.Equal("Book 2", result.Title);
        }
    }
}