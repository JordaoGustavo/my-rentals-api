using System;
using System.Text.RegularExpressions;

namespace my_rental.Domain.Seedwork.ValueObjects
{
    public struct Email
    {
        private readonly string _email;
        private bool _isValid;
        private readonly Regex _validator = new("^\\S+@\\S+\\.\\S+$", RegexOptions.Compiled);

        private Email(string email)
        {
            _email = email;
            _isValid = false;
            Validate(email);
        }

        public static bool TryParse(string value, out Email email)
        {
            email = new Email(value);
            return email.IsValid;
        }

        public static Email Parse(string value)
        {
            var email = new Email(value);

            if (!email.IsValid)
            {
                throw new InvalidOperationException("Email em formato inválido!");
            }

            return email;
        }

        public static implicit operator string(Email email) => email.ToString();

        public static implicit operator Email(string email) => Parse(email);

        public override string ToString()
        {
            return _email;
        }

        public bool IsValid => _isValid;

        private void Validate(string email)
        {
            _isValid = _validator.IsMatch(email);
        }
    }
}
