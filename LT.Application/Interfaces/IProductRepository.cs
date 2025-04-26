using LT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllWithRelationsAsync();
        Task<Product?> GetByIdWithRelationsAsync(int id);

        // TO DO: Add the update and delete methods
        #region answer
        Task<Product?> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        #endregion
    }
}
