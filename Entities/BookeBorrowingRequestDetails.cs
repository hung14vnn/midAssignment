using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace midAssignment.Entities
{
    public class BookeBorrowingRequestDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual BookBorrowingRequest? BookBorrowingRequests { get; set; }
        
    }
}