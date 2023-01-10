using BooksManager.Common;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace BooksManager.JSONRepo
{
    public class JsonBooksRepo : IRepository
    {
        public JsonBooksRepo(string filepath)
        {
            char[] invalidChars = { '<', '>', ':', '\'', '/', '\\', '|', '?', '*' };
            if (string.IsNullOrWhiteSpace(filepath) || filepath.Any(x => invalidChars.Contains(x)))
                throw new ArgumentException(nameof(filepath));

            Filepath = filepath;
        }

        public string Filepath { get; }

        public IEnumerable<Book> GetBooks()
        {
            return JsonSerializer.Deserialize<IEnumerable<Book>>(File.ReadAllText(Filepath));
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            //JsonSerializer.Serialize(File.OpenWrite(Filepath), books);
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(Filepath, json);
        }
    }
}