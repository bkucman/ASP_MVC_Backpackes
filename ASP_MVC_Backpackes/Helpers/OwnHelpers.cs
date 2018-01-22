using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Razor.Configuration;

namespace ASP_MVC_Backpackes.Helpers
{
    public static class OwnHelpers { 
        public static string DDList(string line,string name)
        {
            return String.Format("\"" + name + "\", (IEnumerable<SelectListItem>)ViewBag." + line +
                                 ",\"Wybierz\", new {{ @class = \"form - control\" }}");
            //Rolad @Html.DropDownList("RoleName", (IEnumerable<SelectListItem>)ViewBag.Roles, "Wybierz", new { @class = "form-control" })
        }


        public static HtmlString but1(string action)
        {
            if (action == "Save")
                return new HtmlString("<input type=\"submit\" class=\"btn btn-warning\" value=\"Zapisz\" />");
            else if(action == "Delete")
                return  new HtmlString("<input type=\"submit\" class=\"btn btn-danger\" value=\"Usuń\" />");
            else if(action == "Details")
            {
                return new HtmlString("<input type=\"submit\" class=\"btn btn-primary\" value=\"Szczegóły\" />"); ;
            }else if (action == "Check")
            {
                return new HtmlString("<input type=\"submit\" class=\"btn btn-success\" value=\"Sprawdź\"/>");
            }
            else if(action == "Odbierz")
            {
                return  new HtmlString("<input type=\"submit\" class=\"btn btn-danger\" value=\"Odbierz\"/>");
            }
            return new HtmlString("<input type=\"submit\" class=\"btn btn-primary\" value=\"Klik\" />");

        }
    }
}