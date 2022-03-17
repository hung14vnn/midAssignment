using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace midAssignment.Entities
{
    public class Book
    
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set; }
        [Required]
        public string? BookName { get; set; }
        [Required]
        public string? PhotoFileName { get; set; }
        [Required]
        public int CategoryID {get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category? Categories { get; set; }

    }
        
}
