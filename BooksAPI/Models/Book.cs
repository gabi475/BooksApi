using System;
using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
    }
}