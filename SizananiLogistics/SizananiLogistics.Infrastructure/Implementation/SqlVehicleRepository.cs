using SizananiLogistics.Infrastructure.Models;
using System.Data.SqlClient;
using System.Text;

namespace SizananiLogistics.Infrastructure.Implementation
{
    public class SqlVehicleRepository : IVehicleRepository
    {
        private readonly string _connectionString;

        public SqlVehicleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string deleteQuery = "DELETE FROM Vehicle WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Vehicle[] GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Id, ContractorId, Type, RegistrationNumber, Model, Weight FROM Vehicle";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehicle vehicle = new Vehicle
                            {
                                Id = (int)reader["Id"],
                                ContractorId = (int)reader["ContractorId"],
                                Type = (string)reader["Type"],
                                RegistrationNumber = (string)reader["RegistrationNumber"],
                                Model = (string)reader["Model"],
                                Weight = (double)reader["Weight"]
                            };
                            vehicles.Add(vehicle);
                        }
                    }
                }
            }

            return vehicles.ToArray();
        }

        public Vehicle? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Id, ContractorId, Type, RegistrationNumber, Model, Weight FROM Vehicle WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vehicle
                            {
                                Id = (int)reader["Id"],
                                ContractorId = (int)reader["ContractorId"],
                                Type = (string)reader["Type"],
                                RegistrationNumber = (string)reader["RegistrationNumber"],
                                Model = (string)reader["Model"],
                                Weight = (double)reader["Weight"]
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

        public Vehicle[] GetVehiclesByContractorId(int contractorId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Id, ContractorId, Type, RegistrationNumber, Model, Weight FROM Vehicle WHERE ContractorId = @ContractorId";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ContractorId", contractorId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehicle vehicle = new Vehicle
                            {
                                Id = (int)reader["Id"],
                                ContractorId = (int)reader["ContractorId"],
                                Type = (string)reader["Type"],
                                RegistrationNumber = (string)reader["RegistrationNumber"],
                                Model = (string)reader["Model"],
                                Weight = (double)reader["Weight"]
                            };
                            vehicles.Add(vehicle);
                        }
                    }
                }
            }

            return vehicles.ToArray();
        }

        public void Insert(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string insertQuery = new StringBuilder()
                    .Append("INSERT INTO Vehicle (ContractorId, Type, RegistrationNumber, Model, Weight) ")
                    .Append("VALUES (@ContractorId, @Type, @RegistrationNumber, @Model, @Weight)")
                    .ToString();
                
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ContractorId", vehicle.ContractorId);
                    command.Parameters.AddWithValue("@Type", vehicle.Type);
                    command.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                    command.Parameters.AddWithValue("@Model", vehicle.Model);
                    command.Parameters.AddWithValue("@Weight", vehicle.Weight);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = new StringBuilder()
                    .Append("UPDATE Vehicle ")
                    .Append("SET ContractorId = @ContractorId, Type = @Type, ")
                    .Append("RegistrationNumber = @RegistrationNumber, Model = @Model,")
                    .Append("Weight = @Weight ")
                    .Append("WHERE Id = @Id")
                    .ToString();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", vehicle.Id);
                    command.Parameters.AddWithValue("@ContractorId", vehicle.ContractorId);
                    command.Parameters.AddWithValue("@Type", vehicle.Type);
                    command.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                    command.Parameters.AddWithValue("@Model", vehicle.Model);
                    command.Parameters.AddWithValue("@Weight", vehicle.Weight);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
