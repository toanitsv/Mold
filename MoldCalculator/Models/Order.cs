//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoldCalculator.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public string OutsoleCode { get; set; }
        public string Article { get; set; }
        public string ShoeName { get; set; }
        public Nullable<System.DateTime> CSD { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
    }
}
