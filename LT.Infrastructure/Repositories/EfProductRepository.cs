using LT.Domain.Entities;
using LT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LT.Application.Interfaces;

namespace LT.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly DataContext _db;
        public EfProductRepository(DataContext db) => _db = db;

        public async Task AddAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithRelationsAsync()
        {
            return await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithRelationsAsync(int id)
        {
            return await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // To do: Add the updtae and delete methods
        #region answer
        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await _db.Products.FindAsync(product.Id);
            if (existingProduct == null) return null;
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            _db.Products.Update(existingProduct);
            await _db.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return false;
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
