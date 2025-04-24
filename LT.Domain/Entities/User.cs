using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LT.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Photo { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? LastUpdate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
