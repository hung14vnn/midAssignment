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

        
        // public Product AddProduct(Product product);
        // public Product UpdateProduct(Product product );
        // public Product DeleteProduct(int id);
    }
}