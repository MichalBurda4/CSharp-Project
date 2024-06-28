using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ2_PROJECT.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Login length can't be more than 30.")]
        [Display(Name = "User Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password length can't be more than 30.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "User Opinions")]
        public ICollection<Opinion> Opinions { get; set; }
        public bool IsAdmin { get; set; }
    }
}