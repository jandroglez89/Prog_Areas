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
    
    public partial class T_Catalogo_Pared
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Catalogo_Pared()
        {
            this.T_Ambiente = new HashSet<T_Ambiente>();
        }
    
        public string Cod { get; set; }
        public int Id { get; set; }
        public string CapituloID { get; set; }
        public string Capitulo { get; set; }
        public string Grupo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ambiente> T_Ambiente { get; set; }
    }
}
