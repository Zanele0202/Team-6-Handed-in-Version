//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INF370GabriQAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checkout_Checkin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checkout_Checkin()
        {
            this.Checkout_Checkin_Date = new HashSet<Checkout_Checkin_Date>();
        }
    
        public int Checkout_ID { get; set; }
        public string Checkout_Equip { get; set; }
        public string Checkin_Equip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Checkout_Checkin_Date> Checkout_Checkin_Date { get; set; }
    }
}
