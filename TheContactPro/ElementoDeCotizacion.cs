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
    
    public partial class ElementoDeCotizacion
    {
        public int ElementoDeCotizacionId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> PrecioDeVenta { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> PrecioTotal { get; set; }
        public Nullable<int> CotizacionId { get; set; }
    
        public virtual Cotizacion Cotizacion { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
