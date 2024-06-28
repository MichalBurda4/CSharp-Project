using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PZ2_PROJECT.Models
{
    public class Opinion
    {
        [Key, ForeignKey("Movie")]
        public string MovieID { get; set; }
        
        [Key, ForeignKey("User")]
        public string UserID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "User Login")]
        public string Login { get; set; }

        [StringLength(30)]
        [Display(Name = "User Name")]
        public string? Name { get; set; }

        [StringLength(30)]
        [Display(Name = "Movie Category")]
        public string? Category { get; set; }

        [StringLength(200)]
        [Display(Name = "Review Text")]
        public string ReviewText { get; set; }

        [StringLength(10)]
        [Display(Name = "Rating")]
        public string Rating { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}