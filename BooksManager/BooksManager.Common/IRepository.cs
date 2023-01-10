namespace BooksManager.Common
{
    public interface IRepository
    {
        IEnumerable<Book> GetBooks();

        void SaveBooks(IEnumerable<Book> books);
    }
}