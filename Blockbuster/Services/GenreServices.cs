using Blockbuster.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Services
{
    public class GenreServices
    {
        
        
            private string _ConnectionString;

            public GenreServices(string connectionString)
            {
                this._ConnectionString = connectionString;
            }

            public List<Genre> GetAllGenres()
            {
                var rv = new List<Genre>();
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    var text = @"SELECT * FROM Genre;";
                    var cmd = new SqlCommand(text, connection);
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rv.Add(new Genre(reader));
                    }
                    connection.Close();
                }
                return rv;
            }

        public void AddGenre(Genre genre)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"INSERT into [Genre]  " +
                                "values (@Name);";

                var addCmd = new SqlCommand(text, connection);


                addCmd.Parameters.AddWithValue("@Name", genre.Name);


                connection.Open();
                addCmd.ExecuteNonQuery();
                connection.Close();

            }


        }

    }
}