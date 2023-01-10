namespace BooksManager.Common
{
    public interface IRepository
    {
        IEnumerable<Book> GetBooks();
    }
}