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
    public class Order
    {
        public int Id { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public Nullable<double> TotalMoney { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public bool isDel { get; set; }
    }
}
