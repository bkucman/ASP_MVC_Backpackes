using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_Backpackes.Validators;

namespace ASP_MVC_Backpackes.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [Display(Name = "Producent")]
        public string Name { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Pole jest wymagane.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [IsNIP]
        //[Remote("IsNIPExist","Manufacturers", AdditionalFields = "Name", ErrorMessage = "NIP już istnieje w bazie")]
        public string NIP { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [IsREGON]
        public string REGON { get; set; }


    }
}