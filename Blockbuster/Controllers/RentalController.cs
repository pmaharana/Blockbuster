using Blockbuster.Models;
using Blockbuster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Controllers
{
    public class RentalController : Controller
    {
        const string connectionString =
         @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";

        RentalServices rentalServices = new RentalServices(connectionString);

        public ActionResult Index()
        {
            var newLog = rentalServices.GetEntireLog();
            return View(newLog);
        }




    }
}