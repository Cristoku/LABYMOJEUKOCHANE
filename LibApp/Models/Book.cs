using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Date Added is required")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number in stock is required")]
        [Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}