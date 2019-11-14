//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyBack
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int ID { get; set; }
        public int FrontID { get; set; }
        public int TypeID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Commision { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> AmountChange { get; set; }
    
        public virtual Front Front { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}