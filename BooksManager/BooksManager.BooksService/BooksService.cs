using BooksManager.Common;

namespace BooksManager.BooksService
{
    public class BooksService
    {
        public IRepository Repository { get; }

        public BooksService(IRepository repository)
        {
            Repository = repository;
        }

        public Book? GetBookWithBestPricePagesRatio()
        {
            return Repository.GetBooks()
                             .OrderBy(x => x.Price / x.Pages)
                             .ThenBy(x => x.Price)
                             .FirstOrDefault();
        }
    }
}