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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = customerServices.GetAllCustomers().First(f => f.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var newCustomer = new Customers(collection, id);
            customerServices.UpdateCustomer(newCustomer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = customerServices.GetAllCustomers().First(f => f.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customers customer)
        {

            customerServices.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }


    }
}
