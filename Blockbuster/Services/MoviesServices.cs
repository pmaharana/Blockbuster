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

        public IEnumerable<Movies> GetAllMovies(bool includeGenre = true)
        {
            var rv = new List<Movies>();
            
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"SELECT Movies.Id as Id, Movies.Name as Name, YearReleased, Director, GenreId, IsCheckedOut, Genre.Id as NewId, Genre.Name as Genre" +
                            " from [Movies] ";
                if (includeGenre)
                {
                    text += " JOIN Genre on Movies.GenreId = Genre.Id";
                }
                else
                {

                }

                   
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

        public void AddMovie(Movies movie)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"INSERT INTO[Movies](Name, YearReleased, Director, GenreId, IsCheckedOut) " +
                                "VALUES(@Name, @YearReleased, @Director, @GenreId, @IsCheckedOut)";

                var addCmd = new SqlCommand(text, connection);

                addCmd.Parameters.AddWithValue("@Name", movie.Name);
                addCmd.Parameters.AddWithValue("@YearReleased", movie.YearReleased);
                addCmd.Parameters.AddWithValue("Director", movie.Director);
                addCmd.Parameters.AddWithValue("@GenreId", movie.GenreId);
                addCmd.Parameters.AddWithValue("@IsCheckedOut", movie.IsCheckedOut);

                connection.Open();
                addCmd.ExecuteNonQuery();
                connection.Close();

            }

        }






    }
}