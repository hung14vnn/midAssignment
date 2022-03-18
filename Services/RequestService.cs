using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using midAssignment.Entities;
using midAssignment.Models;

namespace midAssignment.Services
{
    public class RequestService : IRequestService
    {
        private readonly LibraryContext _context;
        public RequestService(LibraryContext context)
        {
            _context = context;
        }
        public bool AddRequest( BookBorrowingRequest request)
        {   
            request.RequestDate=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss"));
            request.Status="Pending";
            _context.BookBorrowingRequests.Add(request);
            _context.SaveChanges();
            return true;
        }
        public List<BookBorrowingRequest> GetRequestsByID(int id)
        {
            return _context.BookBorrowingRequests.Where(s => s.UserID == id).ToList();
        }
        public BookBorrowingRequest DeleteRequest(int id)
        {
            var request = _context.BookBorrowingRequests.Find(id);
            if (request == null)
            {
                return null;
            }
            _context.BookBorrowingRequests.Remove(request);
            _context.SaveChanges();
            return request;
        }
    }
       
}