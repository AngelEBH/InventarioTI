//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventarioTI.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TiposMovimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiposMovimientos()
        {
            this.Movimientos = new HashSet<Movimientos>();
        }
    
        public decimal TipoMovimientoID { get; set; }
        public string TipoMovimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}
