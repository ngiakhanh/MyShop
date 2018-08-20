//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models_Controllers.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupProduct()
        {
            this.Menus = new HashSet<Menu>();
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> isDel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
