using LT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Infrastructure.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Checa si ya existen datos en la bd
            if (_context.Categories.Any() || _context.Tags.Any() || _context.Products.Any())
            {
                return; // Salir si hay datos
            }

            await _context.Database.EnsureCreatedAsync(); // Se asegura que la bd se cree

            // Crear categorías
            var cat1 = new Category { Name = "Electrónica" };
            var cat2 = new Category { Name = "Ropa" };
            _context.Categories.AddRange(cat1, cat2);

            // Crear tags
            var tagA = new Tag { Name = "Nuevo" };
            var tagB = new Tag { Name = "Oferta" };
            _context.Tags.AddRange(tagA, tagB);

            await _context.SaveChangesAsync();

            // Crear productos
            var prod1 = new Product
            {
                Name = "Smartphone XYZ",
                Price = 499.99m,
                Description = "Teléfono inteligente de última generación",
                CategoryId = cat1.Id
            };
            prod1.Tags.Add(tagA);

            var prod2 = new Product
            {
                Name = "Camiseta Casual",
                Price = 19.99m,
                Description = "Camiseta de algodón cómoda",
                CategoryId = cat2.Id
            };
            prod2.Tags.Add(tagB);

            _context.Products.AddRange(prod1, prod2);

            // To do: Agregar datos para Author, Book, Genre
            await _context.SaveChangesAsync();
        }
    }
}
