﻿using Blockbuster.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Services
{
    public class CustomerServices
    {
        private string _ConnectionString;

        public CustomerServices(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public List<Customers> GetAllCustomers()
        {
            var rv = new List<Customers>();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"SELECT * FROM Customers;";
                var cmd = new SqlCommand(text, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Customers(reader));
                }
                connection.Close();
            }
            return rv;
        }

        public void AddCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"INSERT into [CUSTOMERS] (Name, PhoneNumber) " +
                                "VALUES (@Name, @PhoneNumber);";

                var addCmd = new SqlCommand(text, connection);


                addCmd.Parameters.AddWithValue("@Name", customer.Name);
                addCmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
               
                connection.Open();
                addCmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"UPDATE [Customers] " +
                            "SET Name = @Name, PhoneNumber = @PhoneNumber " +
                            " WHERE Id = @Id";

                var cmd = new SqlCommand(text, connection);

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Id", customer.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeleteCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var text = @"DELETE FROM [Customers] " +
                    " WHERE Id = @Id";

                var cmd = new SqlCommand(text, connection);
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }


    }
}