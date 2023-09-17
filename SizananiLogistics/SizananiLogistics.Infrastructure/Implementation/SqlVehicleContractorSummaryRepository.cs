using SizananiLogistics.Infrastructure.Models;

namespace SizananiLogistics.Infrastructure.Implementation
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class SqlVehicleContractorSummaryRepository : IVehicleContractorSummaryRepository
    {
        private readonly string _connectionString;

        public SqlVehicleContractorSummaryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VehicleContractorSummary[] Get()
        {
            List<VehicleContractorSummary> summaries = new List<VehicleContractorSummary>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string selectQuery = "SELECT * FROM ContractorSummaryView";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleContractorSummary summary = new VehicleContractorSummary
                            {
                                ContractorId = (int)reader["ContractorId"],
                                ContractorName = (string)reader["ContractorName"],
                                TotalVehicles = (int)reader["TotalVehicles"],
                                TotalWeight = (double)reader["TotalWeight"]
                            };
                            summaries.Add(summary);
                        }
                    }
                }
            }

            return summaries.ToArray();
        }
    }


}
