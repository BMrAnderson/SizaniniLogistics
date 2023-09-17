using SizananiLogistics.Infrastructure.Models;
using System.Text;

namespace SizananiLogistics.Infrastructure.Implementation
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class SqlContractorRepository : IContractorRepository
    {
        private readonly string _connectionString;

        public SqlContractorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Contractor[] GetAllContractors()
        {
            List<Contractor> contractors = new List<Contractor>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string selectQuery = "SELECT Id, Name, EmailAddress, PhoneNumber FROM Contractor";
             
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contractor contractor = new Contractor
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                EmailAddress = (string)reader["EmailAddress"],
                                PhoneNumber = (string)reader["PhoneNumber"]
                            };
                            contractors.Add(contractor);
                        }
                    }
                }
            }

            return contractors.ToArray();
        }

        public Contractor? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
            
                string selectQuery = new StringBuilder()
                    .Append("SELECT Id, Name, EmailAddress, PhoneNumber ")
                    .Append("FROM Contractor ")
                    .Append("WHERE Id = @Id")
                    .ToString();
            
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Contractor
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                EmailAddress = (string)reader["EmailAddress"],
                                PhoneNumber = (string)reader["PhoneNumber"]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void InsertContractor(Contractor contractor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
            
                string insertQuery = new StringBuilder()
                    .Append("INSERT INTO Contractor (Name, EmailAddress, PhoneNumber) ")
                    .Append("VALUES (@Name, @EmailAddress, @PhoneNumber)")
                    .ToString();
                
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", contractor.Name);
                    command.Parameters.AddWithValue("@EmailAddress", contractor.EmailAddress);
                    command.Parameters.AddWithValue("@PhoneNumber", contractor.PhoneNumber);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
