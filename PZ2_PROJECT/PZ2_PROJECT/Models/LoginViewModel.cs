//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace PZ2_PROJECT.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}