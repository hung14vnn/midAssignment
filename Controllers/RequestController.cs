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
    public class RequestController : ControllerBase
    {
    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly IRequestService _requestService;
    private readonly IBookService _bookService;
    private readonly IUserService _userService;

    public RequestController(ILogger<BookController> logger,IRequestService requestService, IBookService bookService, IUserService userService,IWebHostEnvironment env)
    {
        _logger = logger;
        _bookService = bookService;
        _userService = userService;
        _requestService = requestService;
        _env = env;
    }
        [HttpGet]
        [Route("getRequestsById")]
        public ActionResult<List<BookBorrowingRequest>> GetRequestsByID(int id)
        {
            return _requestService.GetRequestsByID(id);
        }
        [HttpGet]
        [Route("getRequests")]
        public ActionResult<List<BookBorrowingRequest>> GetRequests()
        {
            return _requestService.GetRequests();
        }
        [HttpDelete]
        [Route("deleteRequest")]
        public ActionResult<BookBorrowingRequest> DeleteRequest(int id)
        {
            return _requestService.DeleteRequest(id);
        }
        [HttpGet]
        [Route("getRequestById")]
        public ActionResult<BookBorrowingRequest> GetRequestById(int id)
        {
            return _requestService.GetRequestByID(id);
        }
        [HttpPost]
        [Route("updateRequest")]
        public ActionResult<BookBorrowingRequest> UpdateRequest(BookBorrowingRequest request)
        {
            return _requestService.UpdateRequest(request);
        }
        [HttpPost]
        public ActionResult<bool> Post(BookBorrowingRequest request)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-E1B2MP8B\\SQLEXPRESS;Database=LibraryDb;User ID=sa;Password=123456;")) 
        {
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from [BookBorrowingRequests] where BookID = @BookID", con))
            {
                cmd.Parameters.AddWithValue("BookID", request.BookID);
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            // if exists, show a message error
            if (exists)
                return false;
            else
            {
            var res = new BookBorrowingRequest
            {
                BookID = request.BookID,
                UserID = request.UserID,
            };
            _requestService.AddRequest(res);
            return true;
            }
        }
      

        
    }
    }
 
    }