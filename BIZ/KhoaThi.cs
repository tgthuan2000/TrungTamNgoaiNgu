//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrungTamNgoaiNgu.BIZ
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhoaThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaThi()
        {
            this.DuThis = new HashSet<DuThi>();
            this.PhongThis = new HashSet<PhongThi>();
        }
    
        public int MaKhoaThi { get; set; }
        public string TenKhoa { get; set; }
        public System.DateTime NgayThi { get; set; }
        public bool ChotSo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuThi> DuThis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongThi> PhongThis { get; set; }
    }
}
