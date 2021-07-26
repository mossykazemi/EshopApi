using EshopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopApi.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Task<Product> Add(Product product);
        Task<Product> Find(int id);
        Task<Product> Update(Product product);
        Task<Product> Remove(int id);
        Task<bool> IsExist(int id);
    }
}