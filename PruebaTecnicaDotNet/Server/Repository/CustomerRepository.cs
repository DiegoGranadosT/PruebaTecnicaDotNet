using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Repository
{
    public class CustomerRepository : IRepository<Customers>
    {
        private readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PruebaDbConnection");
        }

        public async Task<Customers> GetById(int id)
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("GetByIdCustomers", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            await sql.OpenAsync();
            Customers response = new();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response = Map(reader);
                }
            }
            return response;

        }

        public async Task<List<Customers>> GetList()
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("GetCustomers", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Customers>();
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
        public async Task<Customers> Add(Customers model)
        {
            using SqlConnection sql = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("AddCustomer", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cName1", model.cName1));
            cmd.Parameters.Add(new SqlParameter("@cName2", model.cName2));
            cmd.Parameters.Add(new SqlParameter("@cLastName1", model.cLastName1));
            cmd.Parameters.Add(new SqlParameter("@cLastName2", model.cLastName2));
            var response = new Customers();
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

        public async Task<Customers> Update(Customers model)
        {
            using SqlConnection sql = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("UpdateCustomer", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cId", model.cId));
            cmd.Parameters.Add(new SqlParameter("@cName1", model.cName1));
            cmd.Parameters.Add(new SqlParameter("@cName2", model.cName2));
            cmd.Parameters.Add(new SqlParameter("@cLastName1", model.cLastName1));
            cmd.Parameters.Add(new SqlParameter("@cLastName1", model.cLastName2));
            var response = new Customers();
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

        private static Customers Map(SqlDataReader reader)
        {
            return new Customers
            {
                cId = (int)reader["cId"],
                cName1 = reader["cName1"].ToString() ?? "",
                cName2 = reader["cName2"].ToString() ?? "",
                cLastName1 = reader["cLastName1"].ToString() ?? "",
                cLastName2 = reader["cLastName2"].ToString() ?? "",
                CustomersPhones = new List<CustomersPhones> 
                {
                    new CustomersPhones { cpPhone =  reader["cpPhone"].ToString() ?? ""}
                }
            };
        }
    }
}
