using Aflame.Dtos;
using Aflame.Models;
using System;
using System.Linq;
using System.Web.Http;


namespace Aflame.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where
                (m => newRental.MovieId.Contains(m.Id)); //To Get Multi Ids of movies

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("This movie is not Available.");

                movie.NumberAvailable--;    

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };


                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();

            
        }

        


    }
}
