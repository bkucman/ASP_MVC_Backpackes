using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_Backpackes.Validators
{
    public class IsREGON : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string REGON;

            if (validationContext.DisplayName == null)
                errorMessage = "Numer Nip jest nie poprawny !";
            else
            {
                errorMessage = FormatErrorMessage(validationContext.DisplayName);
            }

            if(value == null)
            return new ValidationResult("REGON jest wymagany.");

            if (value is string)
                REGON = value.ToString();
            else
            {
                return new ValidationResult("Typ pola przechowywujący REGON nie jest typu string");
            }
            int[] lengths = new[] {7, 9, 14};
            if (!lengths.Contains(REGON.Length)) 
                return new ValidationResult("Zła długość REGON-u");
            int[] weight;

            if(REGON.Length == 7)
            {
                weight = new[] { 8,9, 2, 3, 4, 5};
            }else
            if (REGON.Length == 9)
            {
                weight = new [] { 8, 9, 2, 3, 4, 5, 6, 7 };

            }else 
            if (REGON.Length == 14)
            {
                weight = new[] {2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8};
            }
            else
            {
                weight = new[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
            }
            int k = 0;
            int i = 0;
            for (i = 0; i < REGON.Length-1; i++)
            {
                int temp;
                
                if (!Int32.TryParse(REGON[i].ToString(), out temp))
                    return new ValidationResult("Błedne wartość w polu REGON(dozwolone tylko liczby)");

                k += int.Parse(REGON[i].ToString()) * weight[i];
            }
            int temp1;
            if (!Int32.TryParse(REGON[i].ToString(), out temp1))
                return new ValidationResult("Błedne wartość w polu REGON(dozwolone tylko liczby)");

            int x = k % 11;
            if ( x == 10) x = 0;
            
            if (x != int.Parse(REGON[i].ToString()))
            {
                return new ValidationResult("Niepoprawny REGON");
            }

            return ValidationResult.Success;
        }
    }
}