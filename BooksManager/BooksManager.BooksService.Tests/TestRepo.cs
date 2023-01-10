
using BooksManager.Common;

namespace BooksManager.BooksService.Tests
{
    public class TestRepo : IRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            yield return new Book() { Title = "Book 1", Pages = 100, Price = 50 };
            yield return new Book() { Title = "Book 2", Pages = 200, Price = 50 };
        }
    }
}