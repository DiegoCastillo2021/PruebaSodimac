//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTG_CATALOGO
    {
        public CTG_CATALOGO()
        {
            this.VLC_VALOR_CATALOGO = new HashSet<VLC_VALOR_CATALOGO>();
        }
    
        public int CTG_ID { get; set; }
        public string CTG_DESCRIPCION { get; set; }
        public string CTG_ESTADO { get; set; }
    
        public virtual ICollection<VLC_VALOR_CATALOGO> VLC_VALOR_CATALOGO { get; set; }
    }
}
