using LT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Domain.ValueObjects
{
    /// Email: valida formato en constructor
    public class Email
    {
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
                throw new BusinessException("Email inválido");
            Address = address;
        }
    }
}
