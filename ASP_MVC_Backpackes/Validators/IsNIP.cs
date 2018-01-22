using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_Backpackes.Validators
{
    public class IsNIP : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string NIP;
            
            if(validationContext.DisplayName == null)
                errorMessage = "Numer Nip jest nie poprawny !";
            else
            {
                errorMessage = FormatErrorMessage(validationContext.DisplayName);
            }

            if(value == null)
                return new ValidationResult("NIP jest wymagany.");

            if (value is string)
                NIP = value.ToString();
            else
            {
                return new ValidationResult("Typ pola przechowywujący NIP nie jest typu string");
            }

            if(NIP.Length != 10)
                return new ValidationResult("Zła długość NIP-u");

            int[] weight = {6, 5, 7, 2, 3, 4, 5, 6, 7};
            int k = 0;

            for (int i = 0; i < NIP.Length-1; i++)
            {
                int temp;

                if(!Int32.TryParse(NIP[i].ToString(), out temp))
                    return new ValidationResult("Błedne wartość w polu NIP(dozwolone tylko liczby)");

                    k += int.Parse(NIP[i].ToString()) * weight[i];
                
            }
            int temp1;
            if (!Int32.TryParse(NIP[9].ToString(), out temp1))
                return new ValidationResult("Błedne wartość w polu NIP(dozwolone tylko liczby)");

            if (k%11 != int.Parse(NIP[9].ToString()))
            {
                return new ValidationResult("Niepoprawny NIP");
            }

            return ValidationResult.Success;
        }

    }
}