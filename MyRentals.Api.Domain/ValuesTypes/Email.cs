using System;
using System.Text.RegularExpressions;

namespace MyRentals.Api.Domain.ValuesTypes
{
    public struct Email
    {
        private readonly string _value;
        private const string _pattern = @"^\w+([-+.']\w+)@\w+([-.]\w+).\w+([-.]\w+)*$";
        private static readonly Regex _validator = new(_pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public Email(string email) => _value = email;

        public static implicit operator Email(string email) => Parse(email);

        public static Email Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException("Email inválido");
        }

        public static bool TryParse(string value, out Email email)
        {
            if (!IsValid(value))
            {
                email = null;
                return false;
            }

            email = new Email(value);
            return true;
        }

        public bool IsValid()
        {
            return _validator.IsMatch(_value);
        }

        public static bool IsValid(string value)
        {
            return _validator.IsMatch(value);
        }
    }
}
