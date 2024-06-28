using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ2_PROJECT.Models
{
    public class Movie
    {
        [Key]
        public string MovieID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "Category length can't be more than 30.")]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Reviews")]
        public ICollection<Opinion> Opinions { get; set; }
    }
}