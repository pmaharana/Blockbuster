using Blockbuster.Models;
using Blockbuster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Controllers
{
    public class GenreController : Controller
    {
        const string connectionString =
         @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";

       

        GenreServices genreServices = new GenreServices(connectionString);


        public ActionResult Index()
        {
            var genre = genreServices.GetAllGenres();
            return View(genre);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newGenre = new Genre(collection);
            genreServices.AddGenre(newGenre);
            return RedirectToAction("Index");
        }

    }
}
