using Blockbuster.Models;
using Blockbuster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Controllers
{
    public class MoviesController : Controller
    {
        const string connectionString =
         @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";

        MoviesServices movieServices = new MoviesServices(connectionString);
        GenreServices genreService = new GenreServices(connectionString);

        public ActionResult Index()
        {
            var newMovies = movieServices.GetAllMovies();
            return View(newMovies);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var genre  = genreService.GetAllGenres();
            ViewBag.Genre = genre.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            var newMovie = new Movies(collection);
            movieServices.AddMovie(newMovie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = genreService.GetAllGenres();
            ViewBag.Genre = genre.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            var movie = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var movie = new Movies(collection, id);
            movieServices.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movies movie)
        {
            movieServices.DeleteMovie(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CheckOut(int id)
        {
            var update = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(update);
        }


        [HttpPost]
        public ActionResult CheckOut(Movies movie)
        {

            movieServices.CheckOutMovie(movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CheckIn(int id)
        {
            var update = movieServices.GetAllMovies().First(f => f.Id == id);
            return View(update);
        }

        [HttpPost]
        public ActionResult CheckIn(Movies movie)
        {

            movieServices.CheckInMovie(movie);
            return RedirectToAction("Index");
        }

    }
}


