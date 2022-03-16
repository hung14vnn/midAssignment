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
        public virtual User? Users { get; set; }
        [Required]
        public int BookID {get; set; }
        [ForeignKey("BookID")]
        public virtual ICollection<Book>? Books { get; set; }

    
    }
}