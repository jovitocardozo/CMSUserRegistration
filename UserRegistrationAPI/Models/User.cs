using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationAPI.Models
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        [StringLength(17, MinimumLength =5)]
        public string userName { get; set; }
    }
}
