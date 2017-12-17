//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetAppAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lugar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lugar()
        {
            this.Direcciones = new HashSet<Direcciones>();
            this.Galeria = new HashSet<Galeria>();
        }
    
        public System.Guid Id { get; set; }
        public string Nombre { get; set; }
        public System.Guid Direccion { get; set; }
        public string Telefono { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Horario { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
        public string Latitud { get; set; }
        public string Longitude { get; set; }
        public Nullable<System.Guid> IdCategoria { get; set; }
    
        public virtual CategoriaLugares CategoriaLugares { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direcciones> Direcciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Galeria> Galeria { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
