using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;

namespace midAssignment.Services
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public Category GetCategory(int id);   
        public bool AddBook(Book book);
        public Book DeleteBook(int id);
        public Book GetBookByID(int id);
        public Book UpdateBook(Book book);

    }
}