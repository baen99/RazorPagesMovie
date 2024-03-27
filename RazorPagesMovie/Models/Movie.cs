using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength =3), Required]
    public string Title { get; set; }

    [Display(Name = "Release Date"), DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(50), Required]
    public string Genre { get; set; }
    /* public decimal Price { get; set; } */

    [RegularExpression(@"[A-Z][a-z]*\s[A-Z][a-z]*")]
    public string? Director { get; set; }

    [RegularExpression(@"^[0-9]*/10$"), StringLength(5)]
    public string Rating { get; set; } = string.Empty;

}
