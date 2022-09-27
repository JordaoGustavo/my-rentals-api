using LanguageExt.Common;
using my_rental.Domain.Commons;
using my_rental.Domain.Seedwork.Exceptions;
using my_rental.Domain.Seedwork.Extensions;
using System;
using EmailValueObject = my_rental.Domain.Seedwork.ValueObjects.Email;

namespace my_rental.Domain.Entities
{
    public class Owner : Entity<Owner>
    {
        public string Name { get; set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Owner()
        {
        }

        public Owner(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password.ToHash256();
            Validate();
        }

        public void ChangeName(string newName)
        {
            if (!IsValidName(newName))
            {
                OperationResult = new Result<Owner>(new InvalidDomainOperationException("Você deve informar um nome valido!"));
            }

            Name = newName;
            LastModifiedDate = DateTime.UtcNow;
        }

        public bool IsPasswordValid(string password)
        {
            return Password.Equals(password.ToHash256());
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword.ToHash256();
            LastModifiedDate = DateTime.UtcNow;
        }

        public void HidePassword()
        {
            Password = string.Empty;
        }

        protected void Validate()
        {
            if (!IsValidName(Name))
            {
                OperationResult = new Result<Owner>(new InvalidDomainOperationException("Você deve informar um nome valido!"));
                return;
            }

            if (!IsValidPassword(Password))
            {
                OperationResult = new Result<Owner>(new InvalidDomainOperationException("Você deve informar um senha valida!"));
                return;
            }

            if (!IsValidPassword(Email))
            {
                OperationResult = new Result<Owner>(new InvalidDomainOperationException("Você deve informar um email valido!"));
                return;
            }
        }

        protected static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 70;
        }

        protected static bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password);
        }

        protected static bool IsValidEmail(string email)
        {
            return EmailValueObject.TryParse(email, out _);
        }
    }
}
