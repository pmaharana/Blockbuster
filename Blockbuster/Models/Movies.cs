using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Models
{
    public class Movies
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? YearReleased { get; set; }
        public string Director { get; set; }
        public int? GenreId { get; set; }
        public bool? IsCheckedOut { get; set; }
        public Genre Genre { get; set; }





        public Movies(SqlDataReader reader, bool hasData = true)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.YearReleased = (int)reader["YearReleased"];
            this.Director = reader["Director"]?.ToString();
            this.GenreId = (int)reader["GenreId"];
            this.IsCheckedOut = (bool)reader["IsCheckedOut"];
            if (hasData)
            {
                this.Genre = new Genre
                {
                    Id = (int)reader["NewId"],
                    Name = reader["Genre"].ToString()
                };
            }
            else
            {
                this.Genre = new Genre() { Id = (int)reader["GenreId"] };
            }
        }

        public Movies(FormCollection collection, int id = 0)
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
            this.YearReleased = int.Parse(collection["YearReleased"]);
            this.Director = collection["Director"];
            this.GenreId = int.Parse(collection["GenreId"]);

            this.IsCheckedOut = bool.Parse(collection["IsCheckedOut"]);

        }

    }
}




