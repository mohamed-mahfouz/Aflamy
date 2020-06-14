using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aflame.Models;
using System.Data.Entity;
using Aflame.ViewModels;
using System.Data.Entity.Validation; //Used for catch Error
using System.Data.SqlClient;

namespace Aflame.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detials(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre= genres
            };
            return View("MovieForm",viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {

                movie.DateAdded = DateTime.Now; // This line to avoid Error "The Conversion datatime2 to datetime 
                                                // it's logical cuz we don't send for server Property call DateAdded,
                                                // so we added it to object(movie) before adding to DB....
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = genre
            };

            return View("MovieForm", viewModel);
        }
    }
}