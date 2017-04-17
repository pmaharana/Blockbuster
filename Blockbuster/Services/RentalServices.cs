using Blockbuster.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Services
{
    public class RentalServices
    {
        private string _ConnectionString;

        public RentalServices(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public IEnumerable<RentalLog> GetEntireLog()
        {
            var rv = new List<RentalLog>();

            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"SELECT RentalLog.Id, CustomerId, MovieId, DateCheckedOut, DueDate, ReturnDate, " +
                    "Customers.Id as CustRentId, Customers.Name as CustomerName, PhoneNumber, " +
                    "Movies.Id as MovieRentId, Movies.Name as MovieName, YearReleased, Director, GenreId, IsCheckedOut " +
                    "FROM RentalLog  " +
                    "JOIN Customers on RentalLog.CustomerId = Customers.Id " +
                    "JOIN Movies on RentalLog.MovieId = Movies.Id";



                var cmd = new SqlCommand(text, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new RentalLog(reader));
                }
                connection.Close();
            }
            return rv;
        }


    }
}