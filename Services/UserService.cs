using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;
using midAssignment.Models;

namespace midAssignment.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _context;
        public UserService(LibraryContext context)
        {
            _context = context;
        }
        public bool AddUser(User user)
        {
            user.isAdministrator = false;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public bool GetUser(User user)
        {
         
                  var check = _context.Users.Where(s => s.Username == user.Username && s.Password == user.Password).FirstOrDefault();
                  if (check != null)
                    return true;
                 else
                    return false;

        }
         public User GetUserForRequest(User user)
        {
            return _context.Users.Find(user.Id);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public int GetUserId(string username)
        {
            return _context.Users.Where(s => s.Username == username).FirstOrDefault().Id;
        }


        public User UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    
    }
}