using BooksAPI.Models;
using BooksAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAll();
        }

        [HttpPut]
        public void Add(Book book)
        {
            _bookService.AddBook(book);
        }

        [HttpPost("{id}")]
        public void Edit(string id, Book book)
        {
            _bookService.EditBook(id, book);
        }

        [HttpGet("{propertyName}")]
        public IActionResult SortByProperty(string propertyName)
        {
            try
            {
                var books = _bookService.SortByProperty(propertyName);

                if (!books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{propertyName}/{search}")]
        public IActionResult SortByProperty(string propertyName, string search)
        {
            try
            {
                var books = _bookService.SearchByProperty(propertyName, search);

                if (!books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("published/{year}")]
        public IActionResult SearchByPublishedDateYear(int year)
        {
            try
            {
                var books = _bookService.SearchByPublishedDate(year, null, null);

                if (!books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("published/{year}/{month}")]
        public IActionResult SearchByPublishedDateYearMonth(int year, int month)
        {
            try
            {
                var books = _bookService.SearchByPublishedDate(year, month, null);

                if (!books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("published/{year}/{month}/{day}")]
        public IActionResult SearchByPublishedDateYearMonthDay(int year, int month, int day)
        {
            try
            {
                var books = _bookService.SearchByPublishedDate(year, month, day);

                if (!books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}