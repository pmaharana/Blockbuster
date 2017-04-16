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

        public ActionResult Index()
        {
            var newMovies = movieServices.GetAllMovies();
            return View(newMovies);
        }
            

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    var newMovie = new Movies(collection);
        //    movieServices.AddMovie(newMovie);
        //    return RedirectToAction("Index");
        //}
    }
}


