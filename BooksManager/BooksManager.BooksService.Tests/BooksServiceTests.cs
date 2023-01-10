using System.Linq.Expressions;

namespace BooksManager.BooksService.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void GetBookWithBestPricePagesRatio_2_Books_results_the_Book_2()
        {
            var service = new BooksService(null);

            var result = service.GetBookWithBestPricePagesRatio();

            Assert.Equal("Book 2", result.Title);
        }
    }
}