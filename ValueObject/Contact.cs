//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace ValueObject
{
    public class Contact
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> isDel { get; set; }
    }
}
