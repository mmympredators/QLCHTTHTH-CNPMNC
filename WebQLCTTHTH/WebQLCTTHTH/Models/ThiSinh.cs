//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLCTTHTH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThiSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThiSinh()
        {
            this.CTVT_TS = new HashSet<CTVT_TS>();
        }
    
        public int MaTS { get; set; }
        public string HoTenTS { get; set; }
        public Nullable<System.DateTime> NamSinhTS { get; set; }
        public string GT { get; set; }
        public string DiaChiTS { get; set; }
        public string QueQuanTS { get; set; }
        public string HinhTS { get; set; }
        public Nullable<bool> NopPhi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTVT_TS> CTVT_TS { get; set; }
    }
}
