//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheContactPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oportunidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oportunidad()
        {
            this.Cotizacion = new HashSet<Cotizacion>();
        }
    
        public int OportunidadId { get; set; }
        public Nullable<int> CuentaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Cuenta Cuenta { get; set; }
    }
}
