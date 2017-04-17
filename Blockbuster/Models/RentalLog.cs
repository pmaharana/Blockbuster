using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Models
{
    public class RentalLog
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? MovieId { get; set; }
        public DateTime? DateCheckedOut { get; set; }
        public DateTime? DueDate { get; set; }
        public string ReturnDate { get; set; }
        public Customers Customer { get; set; }
        public Movies Movie { get; set; }

        public RentalLog()
        {

        }

        public RentalLog(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.CustomerId = (int)reader["CustomerId"];
            this.MovieId = (int)reader["MovieId"];
            this.DateCheckedOut = DateTime.Today;

            //using .Date poperty to set DateAdded
            //var dueBackDate = (DateTime)reader["DueBackDate"];
            //var dateString = dueBackDate.AddDays(10);
            this.DueDate = DateTime.Today.AddDays(10);

            this.ReturnDate = "Return Date";
            this.Customer = new Customers
            {
                Id = (int)reader["CustRentId"],
                Name = reader["CustomerName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString()
            };
            this.Movie = new Movies
            {
                Id = (int)reader["MovieRentId"],
                Name = reader["MovieName"].ToString(),
                YearReleased = (int)reader["YearReleased"],
                Director = reader["Director"].ToString(),
                GenreId = (int)reader["GenreId"],
                IsCheckedOut = (bool)reader["IsCheckedOut"]
            };


        }
    }
}