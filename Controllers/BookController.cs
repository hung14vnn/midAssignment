using Microsoft.AspNetCore.Mvc;
using midAssignment.Models;
using midAssignment.Services;
using midAssignment.Entities;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.Net.Http.Headers;

namespace midAssignment.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly IBookService _bookService;
    private readonly IUserService _userService;
    private readonly ICategoryService _categoryService;

    public BookController(ILogger<BookController> logger, IBookService bookService, IUserService userService, ICategoryService categoryService ,IWebHostEnvironment env)
    {
        _logger = logger;
        _bookService = bookService;
        _userService = userService;
        _categoryService = categoryService;
        _env = env;
    }
   

    [HttpGet]
    public IActionResult Get()
    {
        var books =  _bookService.GetBooks();
        return new JsonResult(books);
    }
    [HttpPost]
    public ActionResult<bool> Post(Book book)
    {
        
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-E1B2MP8B\\SQLEXPRESS;Database=LibraryDb;User ID=sa;Password=123456;"))
        {
            
                _bookService.AddBook(book);
                return true;
        }
    }
  
    [HttpDelete]
    [Route("DeleteBook")]
        public ActionResult<Book> DeleteBook(int id)
        {
            return _bookService.DeleteBook(id);
        }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id == null)
            throw new ArgumentNullException("Id is not null here!");
        var res = _bookService.GetBook(id);
        return new JsonResult(res);
    }
    [HttpGet]
    [Route("GetBooksById")]
    public IActionResult GetBooksById(int id)
    {
        var books = _bookService.GetBookByID(id);
        return new JsonResult(books);
    }
    [HttpPost]
    [Route("UpdateBook")]
    public ActionResult<Book> UpdateBook(Book book)
    {
        return _bookService.UpdateBook(book);
    }


    [Route("SaveFile")]
    [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var file= httpRequest.Files[0];
                string filename= file.FileName;
                var path = _env.ContentRootPath + "/Photos/" + filename;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
        
            catch (System.Exception)
            {
                
                return new JsonResult("notfound.png");
            }
        }
        
    
}
