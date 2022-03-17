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
        // public book Addbook(Book book)
        // {
        //     _context.books.Add(book);
        //     _context.SaveChanges();
        //     return book;
        // }
    

        // public book Deletebook(int id)
        // {
        //     var book = _context.books.Find(id);
        //     if (book == null)
        //     {
        //         return null;
        //     }
        //     _context.books.Remove(book);
        //     _context.SaveChanges();
        //     return book;
        // }

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
        

        // public book Updatebook(book book)
        // {   
        //     _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //     _context.SaveChanges();
        //     return book;
        // }
    }
}