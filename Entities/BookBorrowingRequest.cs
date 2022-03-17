using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace midAssignment.Entities
{
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set; }

        [Required]
        public int UserID {get; set; }
        [ForeignKey("UserID")]
        [Required]
        public int BookID {get; set; }
        [ForeignKey("BookID")]
        public virtual Book? Books { get; set; }

    
    }
}