using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_Backpackes.Models
{
    public class Backpack
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [RegularExpression(@"^([a-zA-Z\u0080-\u024F]+(?:. |-| |'))*[a-zA-Z\u0080-\u024F]*")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane.")]
        [Display(Name = "Pojemność")]
        public decimal Capacity { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Pole jest wymagane.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Producent")]
        public int ManufacturerId { get; set; }
    }
}