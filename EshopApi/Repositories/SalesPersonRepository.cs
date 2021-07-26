using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private EshopApi_DBContext _context;

        public SalesPersonRepository(EshopApi_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _context.SalesPersons.ToList();
        }

        public async Task<SalesPerson> Add(SalesPerson salesPerson)
        {
            await _context.AddAsync(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPerson> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(s => s.SalesPersonId == id);
        }

        public async Task<SalesPerson> Update(SalesPerson salesPerson)
        {
            _context.Update(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPerson> Remove(int id)
        {
            var sales = await _context.SalesPersons.SingleAsync(s => s.SalesPersonId == id);
            _context.Remove(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.SalesPersons.AnyAsync(s => s.SalesPersonId == id);
        }
    }
}
