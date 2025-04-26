using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        // FK y navegación hacia Author
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        // Relación N a N con Genre
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
