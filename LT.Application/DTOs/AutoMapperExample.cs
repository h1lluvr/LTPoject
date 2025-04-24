using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.DTOs
{
    // Ejemplo usando records (inmutables, ideal para DTOs sencillos)
    // Coloca estos, y usa AutoMapper o mapeo manual en tu servicio para convertir Product ⇄ ProductDto.
    public class AutoMapperExample
    {
        public record ProductDto(int Id, string Name, decimal Price, string? Category);
        public record ProductCreateDto(string Name, decimal Price, string? Category);
    }
}
