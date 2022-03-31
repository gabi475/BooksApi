using BooksAPI.Database;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;

namespace Seeder
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "books.json";
            string jsonString = File.ReadAllText(fileName);
            var books = JsonSerializer.Deserialize<Book[]>(jsonString);


            var optionsBuilder = new DbContextOptionsBuilder<BookAPIContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Database=BooksAPI;Integrated Security=True");
            using (var context = new BookAPIContext(optionsBuilder.Options))
            {
                context.Database.Migrate();

                foreach (var book in books)
                    context.Books.Add(book);
                context.SaveChanges();
            }
        }
    }
}
