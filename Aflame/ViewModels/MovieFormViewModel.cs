using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aflame.Models;
using System.ComponentModel.DataAnnotations;

namespace Aflame.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required] // we make it Requird instead of Genre cuz it's happend DbEntityValidationError
        public int? GenreId { get; set; } //Foreign Key
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";
                else
                    return "New Movie ";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }     
    }
}