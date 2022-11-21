using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<T> Add(T model);
        public Task<T> Update(T model);
        public Task<T> GetById(int id);
        public Task<List<T>> GetList();
    }
}
