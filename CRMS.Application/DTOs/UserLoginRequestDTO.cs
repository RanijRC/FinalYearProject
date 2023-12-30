using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Application.DTOs
{
    public class UserLoginRequestDTO
    {
        [Required(ErrorMessage = "Username is requried")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is requried")]
        public string? Password { get; set; }
    }
}
