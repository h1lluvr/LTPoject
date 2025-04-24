using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LT.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero")]
        public decimal Price { get; set; }

        // El simbolo ? despues del tipo de dato significa que es opcional, osea la categoría opcional
        [StringLength(100)]
        public string? Description { get; set; }

        // Propiedad calculada no persistida: precio con impuesto incluido (ej. 20%)
        [NotMapped]
        public decimal PriceWithTax => Price * 1.2m;

        // FK hacia Category
        // Definen la relación inversa y la llave foránea.
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
