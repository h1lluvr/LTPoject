using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Domain.Entities
{
    // Ejemplo de relación 1->N.
    // Una Category contiene múltiples Product
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        // Navegación: lista de productos de esta categoría
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
