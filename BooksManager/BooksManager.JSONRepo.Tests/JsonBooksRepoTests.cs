using BooksManager.Common;
using FluentAssertions;

namespace BooksManager.JSONRepo.Tests
{
    public class JsonBooksRepoTests : IDisposable
    {
        public JsonBooksRepoTests()
        {
            //init 
        }

        public void Dispose()
        {
            //test cleanup
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("!$%&/(")]
        public void FilePath_should_be_valid(string path)
        {
            Action action = () => new JsonBooksRepo(path);
            action.Should().Throw<ArgumentException>();

            //Assert.Throws<ArgumentException>(() => new JsonBooksRepo(path));
        }

        [Fact]
        public void SaveBooks_only()
        {
            var b1 = new Book() { Id = 1, Title = "B 1", Pages = 12, Price = 10m };
            var b2 = new Book() { Id = 2, Title = "B 2", Pages = 87, Price = 12m };
            var b3 = new Book() { Id = 3, Title = "B 3", Pages = 4, Price = 14m };
            var repo = new JsonBooksRepo("books.json");

            repo.SaveBooks(new[] { b1, b2, b3 });

            File.Exists("books.json").Should().BeTrue();
        }

        [Fact]
        public void SaveBooks_and_GetBooks_should_be_the_same()
        {
            var b1 = new Book() { Id = 1, Title = "B 1", Pages = 12, Price = 10m };
            var b2 = new Book() { Id = 2, Title = "B 2", Pages = 87, Price = 12m };
            var b3 = new Book() { Id = 3, Title = "B 3", Pages = 4, Price = 14m };
            var books = new[] { b1, b2, b3 }.AsEnumerable();
            var filepath = "books.json";
            var repo = new JsonBooksRepo(filepath);

            repo.SaveBooks(books);
            var loaded = repo.GetBooks();

            loaded.Should().BeEquivalentTo(books);
            File.Delete(filepath);
        }


    }
}