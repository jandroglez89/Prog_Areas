//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog_Areas_Plantilla.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Aire_Fresco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Aire_Fresco()
        {
            this.T_Climatizacion = new HashSet<T_Climatizacion>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Persona { get; set; }
        public Nullable<int> Metro_Cuadrado { get; set; }
    
        public virtual T_AF_Metro_Cuadrado T_AF_Metro_Cuadrado { get; set; }
        public virtual T_AF_Persona T_AF_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Climatizacion> T_Climatizacion { get; set; }
    }
}
