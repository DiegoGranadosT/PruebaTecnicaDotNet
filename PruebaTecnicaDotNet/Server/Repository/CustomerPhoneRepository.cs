using Microsoft.Data.SqlClient;
using PruebaTecnicaDotNet.Server.Models;

namespace PruebaTecnicaDotNet.Server.Repository
{
    public class CustomerPhoneRepository : ICustomerPhoneRepository
    {
        private readonly string _connectionString;
        public CustomerPhoneRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PruebaDbConnection");
        }

        public async Task<List<CustomersPhones>> GetByCustomerId(int id)
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("GetByCustomerIdCustomersPhone", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cId", id));
            var response = new List<CustomersPhones>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(Map(reader));
                }
            }
            return response;
        }

        public async Task<CustomersPhones> GetById(int id)
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("GetByIdCustomersPhone", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cpId", id));
            await sql.OpenAsync();
            CustomersPhones response = new();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = Map(reader);
                }
            }
            return response;
        }

        public async Task<List<CustomersPhones>> GetList()
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("GetCustomersPhone", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<CustomersPhones>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(Map(reader));
                }
            }
            return response;
        }
        public async Task<CustomersPhones> Add(CustomersPhones model)
        {
            using SqlConnection sql = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("AddCustomerPhone", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cId", model.cId));
            cmd.Parameters.Add(new SqlParameter("@cpPhone", model.cpPhone));
            var response = new CustomersPhones();
            await sql.OpenAsync();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = Map(reader);
                }
            }
            return response;
        }

        public async Task<CustomersPhones> Update(CustomersPhones model)
        {
            using SqlConnection sql = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("UpdateCustomerPhone", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cpId", model.cpId));
            cmd.Parameters.Add(new SqlParameter("@cId", model.cId));
            cmd.Parameters.Add(new SqlParameter("@cpPhone", model.cpPhone));
            var response = new CustomersPhones();
            await sql.OpenAsync();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = Map(reader);
                }
            }
            return response;
        }

        private static CustomersPhones Map(SqlDataReader reader)
        {
            return new CustomersPhones
            {
                cId = (int)reader["cId"],
                cpPhone = reader["cpPhone"].ToString() ?? "",
                cpId = (int)reader["cpId"],
            };
        }
    }
}
