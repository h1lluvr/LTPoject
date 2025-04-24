using LT.Domain.Entities;
using LT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LT.Application.Interfaces;

namespace LT.Infrastructure.Repositories
{
    public class EfTagRepository : ITagRepository
    {
        private readonly DataContext _db;
        public EfTagRepository(DataContext db) => _db = db;

        public async Task<IEnumerable<Tag>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _db.Tags
                .Where(t => ids.Contains(t.Id))
                .ToListAsync();
        }
    }
}
