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
        public bool AddUser(User user);
        public User DeleteUser(int id);
        public bool GetUser(User user);
        public User GetUserForRequest(User user);
        public int GetUserId(string username);
        public bool GetUserPermission(string username);
        public List<User> GetUsers();
        public User UpdateUser(User user);
        public User GetUserById(int id);
        
    }
}