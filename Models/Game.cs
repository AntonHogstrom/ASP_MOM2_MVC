using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_MOM2.Models
{
	public class GameModel
	{
        [Display(Name = "Title ")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Display(Name = "Description ")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Image URL ")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(200)]
        public string? Image { get; set; }

        [Display(Name = "Trailer URL ")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(200)]
        public string? Trailer { get; set; }

        [Display(Name = "PEGI ")]
        [Required(ErrorMessage = "Required")]
        public int? Age { get; set; }

        [Display(Name = "Rating ")]
        [Required(ErrorMessage = "Required")]
        public int? Rating { get; set; }
    }
}

