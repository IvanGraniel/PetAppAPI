using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAppAPI.Models
{
    public class CategoriaModel
    {
      public Guid id { get; set; }
      public String nombre { get; set; }
      public String Imagen { get; set; } 
    }
}