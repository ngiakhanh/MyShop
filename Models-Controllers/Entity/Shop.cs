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
    
    public partial class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public Nullable<int> Province_Id { get; set; }
        public Nullable<bool> isDel { get; set; }
    
        public virtual Province Province { get; set; }
    }
}
