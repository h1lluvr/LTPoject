using LT.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<int> CreateAsync(ProductCreateDto dto);
        Task<ProductDto> GetByIdAsync(int id);

        //TO DO: Edit and Delete service
    }
}
