using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAppAPI.Models
{
    public class LugarModel
    {
       public String nombre { get; set; }
       public  String telefono { get; set; }
       public String email { get; set; }
       public String horario { get; set; }
       public String municipio { get; set; }
        public String latitud { get; set; }
        public String longitud { get; set; }
        public String categoria { get; set; }
        public String direccion { get; set; }
        public String twitter { get; set; }
        public String facebook { get; set; }
    }
}