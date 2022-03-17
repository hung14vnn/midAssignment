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
    public class UserController : ControllerBase
    {
    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly IBookService _bookService;
    private readonly IUserService _userService;

    public UserController(ILogger<BookController> logger, IBookService bookService, IUserService userService,IWebHostEnvironment env)
    {
        _logger = logger;
        _bookService = bookService;
        _userService = userService;
        _env = env;
    }
        [HttpPost]
        [Route("login")]
        public ActionResult<bool> PostLogin(UserLoginModel user)
        {
            var res = _userService.GetUser(user);
            if (res == false)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        [HttpPost]
        [Route("register")]
        public ActionResult<bool> Post(User user)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-E1B2MP8B\\SQLEXPRESS;Database=LibraryDb;User ID=sa;Password=123456;")) 
        {
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from [Users] where Username = @Username", con))
            {
                cmd.Parameters.AddWithValue("Username", user.Username);
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            // if exists, show a message error
            if (exists)
                return false;
            else
            {
                _userService.AddUser(user);
                return true;
            }
        }
        
        //create a string MD5
        // public static string GetMD5(string str)
        // {
        //     MD5 md5 = new MD5CryptoServiceProvider();
        //     byte[] fromData = Encoding.UTF8.GetBytes(str);
        //     byte[] targetData = md5.ComputeHash(fromData);
        //     string byte2String = null;
 
        //     for (int i = 0; i < targetData.Length; i++)
        //     {
        //         byte2String += targetData[i].ToString("x2");
 
        //     }
        //     return byte2String;
        // }
    }
    }
}