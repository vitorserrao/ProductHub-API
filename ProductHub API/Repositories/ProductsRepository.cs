using Microsoft.EntityFrameworkCore;
using ProductHub_API.Data;
using ProductHub_API.Models;
using ProductHub_API.Repositories.Interfaces;

namespace ProductHub_API.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductsModel>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductsModel?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Add(ProductsModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductsModel product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
