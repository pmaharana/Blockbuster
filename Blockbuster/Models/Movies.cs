using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Models
{
    public class Movies
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? YearReleased { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public bool? IsCheckedOut { get; set; }



        public Movies(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.YearReleased = (int)reader["YearReleased"];
            this.Director = reader["Director"]?.ToString();
            this.Genre = reader["Genre"]?.ToString();
            this.IsCheckedOut = (bool)reader["IsCheckedOut"];
        }




        //public Customers(FormCollection collection, int id = 0)
        //{
        //    if (id > 0)
        //    {
        //        this.Id = id;
        //    }
        //    else
        //    {
        //        int _id;
        //        int.TryParse(collection["Id"], out _id);
        //        if (_id > 0)
        //        {
        //            this.Id = _id;
        //        }
        //    }
        //    this.Name = collection["Name"];
        //    this.PhoneNumber = collection["PhoneNumber"];

        //}

    }
}