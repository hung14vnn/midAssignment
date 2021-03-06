using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using midAssignment.Entities;
using midAssignment.Models;

namespace midAssignment.Services
{
    public interface IRequestService
    {
        public bool AddRequest(BookBorrowingRequest request);
        public List<BookBorrowingRequest> GetRequests();
        public List<BookBorrowingRequest> GetRequestsByID(int id);
        public BookBorrowingRequest DeleteRequest(int id);
        public BookBorrowingRequest GetRequestByID(int id);
        public BookBorrowingRequest UpdateRequest(BookBorrowingRequest request);
        

    }
}