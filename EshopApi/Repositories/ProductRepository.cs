using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private EshopApi_DBContext _context;

        public ProductRepository(EshopApi_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Find(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(int id)
        {
            var product = await _context.Products.SingleAsync(p => p.ProductId == id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Products.AnyAsync(p => p.ProductId == id);
        }
    }
}
