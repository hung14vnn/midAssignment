using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace midAssignment.Entities
{
 public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [DefaultValue(false)]
        public Boolean? isAdministrator { get; set; }
        [DefaultValue(null)]
        public virtual ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
    

    }
}