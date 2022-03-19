using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using midAssignment.Entities;

namespace midAssignment.Models
{
    public class UserUpdateModel
    {
        [Required]
        public bool isAdministrator { get; set; }
    }
    
  
}