﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title of the book is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The author's name is required.")]
        public string Author { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number in stock is required")]

        [Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}
