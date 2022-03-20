using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;

namespace midAssignment.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryContext _context;
        public CategoryService(LibraryContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
