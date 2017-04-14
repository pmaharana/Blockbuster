using Blockbuster.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Services
{
    public class MoviesServices
    {
        private string _ConnectionString;

        public MoviesServices(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public List<Movies> GetAllMovies()
        {
            var rv = new List<Movies>();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"SELECT Movies.Id, Movies.Name, YearReleased, Director, Genre.Name as Genre, IsCheckedOut " +
                    "FROM Movies " +
                    "JOIN Genre on Movies.GenreId = Genre.Id;";

                var cmd = new SqlCommand(text, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Movies(reader));
                }
                connection.Close();
            }
            return rv;
        }


    }
}