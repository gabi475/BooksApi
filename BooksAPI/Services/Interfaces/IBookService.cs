using BooksAPI.Models;
using System.Collections.Generic;

namespace BooksAPI.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        void AddBook(Book book);
        void EditBook(string id, Book book);
        Book GetById(string id);
        List<Book> SearchByProperty(string propertyName, string search);
        List<Book> SortByProperty(string propertyName);
        List<Book> SearchByPublishedDate(int year, int? month, int? day);
    }
}
