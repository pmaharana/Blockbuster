﻿using System;
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
        public string DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customers Customer { get; set; }
        public Movies Movie { get; set; }

        //public RentalLog(SqlDataReader reader)
        //{
        //    this.Id = (int)reader["Id"];
        //    this.CustomerId = (int)reader["CustomerId"];
        //    this.MovieId = (int)reader["MovieId"];
        //    this.DateCheckedOut = (DateTime)reader["DateCheckedOut"];

        //    //using .Date poperty to set DateAdded
        //    var dueBackDate = (DateTime)reader["DueBackDate"];
        //    var dateString = dueBackDate.AddDays(10).ToShortDateString();
        //    this.DueDate = dateString;
        //}
    }
}