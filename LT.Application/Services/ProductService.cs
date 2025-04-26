using LT.Application.DTOs;
using LT.Domain.Entities;
using LT.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ITagRepository _tagRepo;

        public ProductService(IProductRepository productRepo, ITagRepository tagRepo)
        {
            _productRepo = productRepo;
            _tagRepo = tagRepo;
        }

        public async Task<int> CreateAsync(ProductCreateDto dto)
        {
            // Crear la entidad con propiedades básicas
            var entity = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };

            // Asociar tags si se proporcionan
            if (dto.TagIds != null && dto.TagIds.Any())
            {
                var tags = await _tagRepo.GetByIdsAsync(dto.TagIds);
                foreach (var tag in tags)
                {
                    entity.Tags.Add(tag);
                }
            }

            await _productRepo.AddAsync(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var list = await _productRepo.GetAllWithRelationsAsync(); // Incluye Category y Tags
            return list.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                Tags = p.Tags?.Select(t => new TagDto { Id = t.Id, Name = t.Name }).ToList()
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _productRepo.GetByIdWithRelationsAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                Tags = p.Tags?.Select(t => new TagDto { Id = t.Id, Name = t.Name }).ToList()
            };
        }

        // TO DO: Update and Delete
        #region answer
        public async Task<ProductDto> UpdateAsync(ProductUpdateDto dto)
        {
            var product = await _productRepo.GetByIdWithRelationsAsync(dto.Id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.CategoryId = dto.CategoryId;
            // Actualizar tags

            if (dto.TagIds != null)
            {
                // Limpiar tags existentes
                product.Tags.Clear();

                // Añadir nuevos tags
                var tags = await _tagRepo.GetByIdsAsync(dto.TagIds);
                foreach (var tag in tags)
                {
                    product.Tags.Add(tag);
                }
            }

            await _productRepo.UpdateAsync(product);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                Tags = product.Tags?.Select(t => new TagDto { Id = t.Id, Name = t.Name }).ToList()
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepo.GetByIdWithRelationsAsync(id);
            if (product == null) return false;
            await _productRepo.DeleteAsync(product.Id);
            return true;
        }
        #endregion
    }
}
