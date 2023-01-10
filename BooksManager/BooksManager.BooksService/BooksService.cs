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

        public Book GetBookWithBestPricePagesRatio()
        {
            throw new NotImplementedException();
        }
    }
}