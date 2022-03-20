using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;

namespace midAssignment.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public bool AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }
    

        public Book DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return null;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }

        public Book GetBook(int id)
        {   
            return _context.Books.Find(id);
        }
         public Category GetCategory(int id)
        {   
            return _context.Categories.Find(id);
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }
        

        public Book UpdateBook(Book book)
        {   
            var bookToUpdate = _context.Books.Find(book.Id);
            if (bookToUpdate == null)
            {
                return null;
            }
            bookToUpdate.BookName = book.BookName;
            bookToUpdate.CategoryID = book.CategoryID;  
            bookToUpdate.PhotoFileName = book.PhotoFileName;
            bookToUpdate.Categories = book.Categories;
            _context.SaveChanges();
            return bookToUpdate;
            
        }
    }
}