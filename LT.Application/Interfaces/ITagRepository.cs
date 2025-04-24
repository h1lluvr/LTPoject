using LT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Application.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
