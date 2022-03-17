using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;
using midAssignment.Models;

namespace midAssignment.Services
{
    public interface IUserService
    {
        public User AddUser(User user);
        public User DeleteUser(int id);
        public bool GetUser(UserLoginModel user);
        public List<User> GetUsers();
        public User UpdateUser(User user);
    }
}