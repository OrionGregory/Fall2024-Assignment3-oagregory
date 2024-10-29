using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Url]
        public string IMDBLink { get; set; }

        public string Genre { get; set; }

        [Range(1888, 2100)]
        public int Year { get; set; }

        public string Poster { get; set; } // URL or file path to the poster

        // Navigation property for actors in the movie
        //    public ICollection<MovieActor> MovieActors { get; set; }

        //    // AI reviews for the movie
        //    public ICollection<AIReview> AIReviews { get; set; }
        //}
    }
}
