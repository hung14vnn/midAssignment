using Microsoft.AspNetCore.Mvc;
using midAssignment.Models;
using midAssignment.Services;
using midAssignment.Entities;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace midAssignment.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService, IWebHostEnvironment env)
    {
        _logger = logger;
        _bookService = bookService;
        _env = env;
    }
   

    [HttpGet]
    public IActionResult Get()
    {
        var books =  _bookService.GetBooks();
        var res = from book in books
                    select new BookViewModel
                    {
                        Id = book.Id,
                        BookName = book.BookName,
                        CategoryID = book.CategoryID,
                        Categories = new Category {
                          Id= _bookService.GetCategory(book.CategoryID).Id,
                          Name = _bookService.GetCategory(book.CategoryID).Name
                        }
                    };
        return new JsonResult(res);
    }
    // [HttpPost]
    // public IActionResult Post(ProductCreateModel product)
    // {
    //     var res = new Product
    //     {
    //         Name = product.Name,
    //         Manufacturer = product.Manufacturer,
    //         CategoryID = product.CategoryID
    //     };
    //     _productService.AddProduct(res);
    //     return Ok(res);
    // }
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
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     if (id == null)
    //         throw new ArgumentNullException("Id is not null here!");
    //     _productService.DeleteProduct(id);
    //     return Ok();
    // }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id == null)
            throw new ArgumentNullException("Id is not null here!");
        var res = _bookService.GetBook(id);
        return new JsonResult(res);
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
