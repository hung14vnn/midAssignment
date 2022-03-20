using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Models;
using midAssignment.Services;
using midAssignment.Entities;
using Microsoft.Data.SqlClient;

namespace midAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly ICategoryService _categoryService;
    private readonly IBookService _bookService;
    private readonly IUserService _userService;

    public CategoryController(ILogger<BookController> logger,ICategoryService categoryService, IBookService bookService, IUserService userService,IWebHostEnvironment env)
    {
        _logger = logger;
        _bookService = bookService;
        _userService = userService;
        _categoryService = categoryService;
        _env = env;
    }
        [HttpGet]
        [Route("GetCategories")]    
        public IActionResult Get()
        {
            var categories =  _categoryService.GetCategories();
            return new JsonResult(categories);
        }
 
    }
}