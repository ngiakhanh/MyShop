//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace ValueObject
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public Nullable<double> Price { get; set; }
        public string Image { get; set; }
        public Nullable<double> PriceNew { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> GroupProduct_Id { get; set; }  
        public virtual GroupProduct GroupProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public bool isDel { get; set; }
    }
}
