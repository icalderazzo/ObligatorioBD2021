using Obligatorio.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;


namespace Obligatorio.Domain
{
    public class UserValidator : IValidator<Usuario>
    {
        public (bool,string) Validate(Usuario user)
        {
            bool validCi = ValidateCi(Convert.ToString(user.Cedula));
            
            // Check valid CI
            if(!validCi){
                return (false, "La cédula ingresada no es válida");
            }
            
            // Check valid email
            if(!IsValidEmail(user.Correo)){
                return (false, "El email ingresado no es válido");
            }
            
            return (true,"");
        }

        private bool IsValidEmail(string email)
        {
            return email != null && new EmailAddressAttribute().IsValid(email);
        }

        private int ValidationDigit(string ci)
        {
            var a = 0;
            var i = 0;
            if (ci.Length  <= 6)
            {
                for (i = ci.Length; i < 7; i++)
                {
                    ci = '0' + ci;
                }
            }
            for (i = 0; i < 7; i++)
            {
                a += (Int32.Parse("2987634"[i].ToString()) * Int32.Parse(ci[i].ToString())) % 10;
            }
            if (a % 10 == 0)
            {
                return 0;
            }
            else
            {
                return 10 - a % 10;
            }
        }

        private bool ValidateCi(string ci)
        {
            var dig = ci[ci.Length - 1];
            ci = ci.Substring(0, ci.Length - 1);

            int validDigitCalculated = ValidationDigit(ci);
            return (Int32.Parse(dig.ToString()) == validDigitCalculated);
        } 
    }
}