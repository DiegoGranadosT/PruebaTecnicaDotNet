using PruebaTecnicaDotNet.Server.Models;

namespace PruebaTecnicaDotNet.Server.Repository
{
    public interface ICustomerPhoneRepository : IRepository<CustomersPhones> 
    {
        public Task<List<CustomersPhones>> GetByCustomerId(int id);
    }
}
