//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.orders = new HashSet<orders>();
        }
    
        public int ID_product { get; set; }
        public Nullable<int> id_type_of_furniture { get; set; }
        public Nullable<int> quantity_product { get; set; }
        public Nullable<int> id_suppliers { get; set; }
        public Nullable<decimal> price { get; set; }
        public string name_product { get; set; }
        public string color { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }
        public virtual suppliers suppliers { get; set; }
        public virtual types_of_furniture types_of_furniture { get; set; }
    }
}
