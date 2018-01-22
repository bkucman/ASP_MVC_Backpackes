using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_MVC_Backpackes.Models;

namespace ASP_MVC_Backpackes.ViewModel
{
    public class BackpackFormViewModel
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public Backpack Backpack { get; set; }
    }
}