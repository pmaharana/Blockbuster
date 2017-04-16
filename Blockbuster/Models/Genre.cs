using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Models
{
    public class Genre
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public Genre()
        {

        }
        public Genre(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();

        }

        public Genre(FormCollection collection, int id = 0)
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
        }
    }
}