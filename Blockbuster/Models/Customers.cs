using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Models
{
    public class Customers
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Customers(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.PhoneNumber = reader["PhoneNumber"]?.ToString();

        }


        public Customers(FormCollection collection, int id = 0)
        {
            if (id > 0)
            {
                this.Id = id;
            }
            else
            {
                int _id;
                int.TryParse(collection["Id"], out _id);
                if (_id > 0)
                {
                    this.Id = _id;
                }
            }
            this.Name = collection["Name"];
            this.PhoneNumber = collection["PhoneNumber"];

        }
    }
}