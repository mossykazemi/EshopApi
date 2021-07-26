using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Contracts
{
    public interface ISalesPersonRepository
    {
        IEnumerable<SalesPerson> GetAll();
        Task<SalesPerson> Add(SalesPerson salesPerson);
        Task<SalesPerson> Find(int id);
        Task<SalesPerson> Update(SalesPerson salesPerson);
        Task<SalesPerson> Remove(int id);
        Task<bool> IsExist(int id);
    }
}