using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Database
{
    public class BookAPIContext : DbContext
    {
        public BookAPIContext(DbContextOptions<BookAPIContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}