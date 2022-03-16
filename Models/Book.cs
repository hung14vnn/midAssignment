using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using midAssignment.Entities;

namespace midAssignment.Models
{
    public class BookViewModel
    {
        public int Id{get; set; }

        public string? BookName { get; set; }
        public string? PhotoFileName { get; set; }
        public int CategoryID {get; set; }
        
        public Category? Categories { get; set; }
    }
    
    public class BookCreateModel 
    {
        [Required]
        public string? BookName { get; set; }
        [Required]
        public int CategoryID {get; set; }
    }
}