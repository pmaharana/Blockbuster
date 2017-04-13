using Blockbuster.Models;
using Blockbuster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Controllers
{
    public class CustomerController : Controller
    {
        const string connectionString =
         @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";

        CustomerServices customerServices = new CustomerServices(connectionString);

        
        public ActionResult Index()
        {
            var customers = customerServices.GetAllCustomers();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newCustomer = new Customers(collection);
            customerServices.AddCustomer(newCustomer);
            return RedirectToAction("Index");
        }
            


    }
}
