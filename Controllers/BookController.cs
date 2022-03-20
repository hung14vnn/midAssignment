using Microsoft.AspNetCore.Mvc;
using midAssignment.Models;
using midAssignment.Services;
using midAssignment.Entities;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

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
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from [Books] where Id = @Id", con))
            {
                cmd.Parameters.AddWithValue("Id", book.Id);
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            // if exists, show a message error
            if (exists)
                return false;
            else
            {
                _bookService.AddBook(book);
                return true;
            }
        }
    }
    // [HttpPut("{id}")]
    // public IActionResult Put(ProductCreateModel product, int id)
    // {
    //     var res = new Product
    //     {   Id = id,
    //         Name = product.Name,
    //         Manufacturer = product.Manufacturer,
    //         CategoryID = product.CategoryID
    //     };
    //     _productService.UpdateProduct(res);
    //     return Ok(res);
    // }
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
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (System.Exception)
            {
                
                return new JsonResult("notfound.png");
            }
        }
        
    
}
