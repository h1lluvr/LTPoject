using LT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.Domain.ValueObjects
{
    /// Money: representa un monto con una moneda
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new BusinessException("El monto no puede ser negativo");
            if (string.IsNullOrWhiteSpace(currency)) throw new BusinessException("La moneda es obligatoria");
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new BusinessException("No se pueden sumar montos de distintas monedas");
            return new Money(Amount + other.Amount, Currency);
        }

        public override bool Equals(object? obj) =>
            obj is Money m && m.Amount == Amount && m.Currency == Currency;

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
    }
}
